using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;
using System.Text.RegularExpressions;

namespace Roster_Application.Controllers
{
    public class ScheduleController : Controller
    {
        ApplicationDbContext _db;
        ICategoryModel? _categoryModel;
        IClientModel? _clientModel;
        IEmployeeModel? _employeeModel;
        IScheduleModel? _scheduleModel;
        public ScheduleController(ApplicationDbContext db, ICategoryModel categoryModel, IClientModel clientModel, IEmployeeModel employeeModel, IScheduleModel scheduleModel)
        {
            _db = db;
            _clientModel = clientModel;
            _employeeModel = employeeModel;
            _scheduleModel = scheduleModel;
            _categoryModel = categoryModel;
        }
        [HttpPost]
        public IActionResult ScheduleOptions()
        {
            return View();
        }
        public IActionResult CreateNewSchedule()
        {
            _scheduleModel!.ScheduleName = "";
            return View(_scheduleModel);
        }
        [HttpPost]
        public IActionResult SCreateNewSchedule(string newSchName, string monHrs, string tueHrs, string wedHrs, string thurHrs, string friHrs,
            string satHrs, string sunHrs, string totHours)
        {
            bool isValid = false;

            _scheduleModel!.ScheduleName = newSchName;
            _scheduleModel.ScheduleMonTotHours = int.Parse(monHrs);
            _scheduleModel.ScheduleTueTotHours = int.Parse(tueHrs);
            _scheduleModel.ScheduleWedTotHours = int.Parse(wedHrs);
            _scheduleModel.ScheduleThurTotHours = int.Parse(thurHrs);
            _scheduleModel.ScheduleFriTotHours = int.Parse(friHrs);
            _scheduleModel.ScheduleSatTotHours = int.Parse(satHrs);
            _scheduleModel.ScheduleSunTotHours = int.Parse(sunHrs);
            _scheduleModel.ScheduleTotalHours = int.Parse(totHours);


            _db.Add(_scheduleModel);
            _db.SaveChanges();
            isValid = true;
            TempData["Successful"] = "New Schedule successfully saved.";

            return Json(new { isValid });
        }
        [HttpPost]
        public IActionResult EditExistingSchedule()
        {
            var data = _db.Schedules.ToList();
            return View(data);
        }
        public IActionResult EditSchedule(string selectedSchedule, string newSchName, string monHrs, string tueHrs, string wedHrs, string thurHrs,
            string friHrs, string satHrs, string sunHrs, string totHours)
        {
            var schedule = _db.Schedules.FirstOrDefault(x => x.ScheduleName == selectedSchedule); //Get the object according to the name of the schedule passed to the method
            var clients = _db.Clients.ToList(); //Get the list of all the clients
            bool isValid = false;


            foreach (var client in clients) //Loop through all the clients 
            {
                if (client.ScheduleID == schedule!.ScheduleId) //check if the schedule id of the client matches to the schedule id of the schedule which is being edited 
                {
                    client.TotalHours = int.Parse(totHours);//if it matches get the new total hours passed as a parameter and save it in the total hours of the client with the same schedule.
                    _db.Clients.Update(client); //update the database
                    _db.SaveChanges(); //save the changes 

                }
            }
            try
            {
                //update the schedule with the data passed as parameters 
                schedule!.ScheduleName = newSchName;
                schedule.ScheduleMonTotHours = int.Parse(monHrs);
                schedule.ScheduleTueTotHours = int.Parse(tueHrs);
                schedule.ScheduleWedTotHours = int.Parse(wedHrs);
                schedule.ScheduleThurTotHours = int.Parse(thurHrs);
                schedule.ScheduleFriTotHours = int.Parse(friHrs);
                schedule.ScheduleSatTotHours = int.Parse(satHrs);
                schedule.ScheduleSunTotHours = int.Parse(sunHrs);
                schedule.ScheduleTotalHours = int.Parse(totHours);

                _db.Schedules.Update(schedule);//update the database
                _db.SaveChanges();//save the changes

                TempData["Successful"] = "Data Saved Successsfully!";
                isValid = true;
            }
            catch (Exception ex) 
            {
                TempData["Unsuccessful"] = "Data note saved due to the following error:/n/n" + ex.Message;
                isValid = false;
            }

            return Json(new { isValid });
        }
        public IActionResult SCheckScheduleName(string inputValue) //This method is called by the Jquery script in the CreateNewSchedule view to check if the category name
                                                                   //already exists in database without refreshing the whole page.
        {
            bool isValid;
            string checkForWhitespace = @"\s";

            bool whitespaceDedected = false;

            var checkClientName = _db.Schedules.FirstOrDefault(x => x.ScheduleName == inputValue);//checks if the value of inputValue exists in the database and returns the name if it exists.


            if (checkClientName == null && inputValue != null)// && !whitespaceDedected)//If name does not exist in DB & name is not null & no whitespaces dedected
            {
                whitespaceDedected = Regex.IsMatch(inputValue, checkForWhitespace);
                if (!whitespaceDedected)
                {
                    isValid = true;
                    _scheduleModel!.ScheduleName = inputValue;
                }
                else
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            return Json(new { isValid });
        }
        [HttpPost]
        public IActionResult SGetData(string scheduleName) //This method is called by the Jquery script in the EditExistingSchedule to get the data from the database according to the name of the selected schedule. 
        {
            var data = _db.Schedules.FirstOrDefault(x => x.ScheduleName == scheduleName); //Search for the name of schedule and pass it to variable data.
            return Json(data); //return data to the jQuery script.
        }
        [HttpPost]
        public IActionResult SCheckDataPriorSaving(bool editingCurrentSchedule, string selectedSchedule, string newSchName, string monHrs, string tueHrs, string wedHrs,
            string thurHrs, string friHrs, string satHrs, string sunHrs)
        {

            var obj = _db.Schedules.FirstOrDefault(x => x.ScheduleName == newSchName);//Check if the new schedule name already exists in the database.

            string checkForWhitespace = @"\s"; //Regex expression which checks for a whitespace in a string,
            string checkHoursFormat = "^[0-9]+$";//Regex expression which checks if a string contains only numbers without whitespaces.
            bool correctNumberFormat;
            bool whitespaceDetected = false;
            string error = "Orange";
            string noError = "Green";
            int totalHours = 0;

            List<string> errorsList = new List<string>();
            List<string> hoursList = new List<string>() { monHrs, tueHrs, wedHrs, thurHrs, friHrs, satHrs, sunHrs };

            int errors = 0;
            if (editingCurrentSchedule)
            {
                if (newSchName == null)
                {
                    errors++;
                    errorsList.Add(error);
                }
                else
                {
                    whitespaceDetected = Regex.IsMatch(newSchName, checkForWhitespace);
                }


                if (whitespaceDetected)
                {
                    errors++;
                    errorsList.Add(error);
                }
                else if (obj != null && newSchName != selectedSchedule)
                {
                    errors++;
                    errorsList.Add(error);
                }
                else if (obj != null && obj!.ScheduleName == selectedSchedule)
                {
                    errorsList.Add(noError);
                }
                else if (!whitespaceDetected && obj == null && newSchName != null)
                {
                    errorsList.Add(noError);
                }
            }
            else
            {
                errorsList.Add(noError);
            }

            foreach (string item in hoursList)
            {
                if (item != null)
                {
                    correctNumberFormat = Regex.IsMatch(item, checkHoursFormat);
                    if (correctNumberFormat)
                    {
                        errorsList.Add(noError);
                        totalHours += int.Parse(item);
                    }
                    else
                    {
                        errors++;
                        errorsList.Add(error);
                    }
                }
                else
                {
                    errors++;
                    errorsList.Add(error);
                }
            }
            errorsList.Add(errors.ToString());
            return Json(errorsList);
        }
    }
}