using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Roster_Application.Data;
using Roster_Application.Models;
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

        [HttpPost, ActionName("Create Schedule")]
        public IActionResult CreateNewSchedule(ScheduleModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("CreateNewSchedule", "Schedule");
        }
        [HttpPost]
        public IActionResult EditExistingSchedule()
        {
            var data = _db.Schedules.ToList();
            return View(data);
        }
        public IActionResult EditSchedule(string selectedSchedule, string newSchName, string monHrs, string tueHrs, string wedHrs, string thurHrs, string friHrs, string satHrs, string sunHrs)
        {
            var obj = _db.Schedules.FirstOrDefault(x => x.ScheduleName == selectedSchedule);
            bool isValid = false;

            obj!.ScheduleName = newSchName;
            obj.ScheduleMonTotHours = int.Parse(monHrs);
            obj.ScheduleTueTotHours = int.Parse(tueHrs);
            obj.ScheduleWedTotHours = int.Parse(wedHrs);
            obj.ScheduleThurTotHours = int.Parse(thurHrs);
            obj.ScheduleFriTotHours = int.Parse(friHrs);
            obj.ScheduleSatTotHours = int.Parse(satHrs);
            obj.ScheduleSunTotHours = int.Parse(sunHrs);

            _db.Schedules.Update(obj);
            _db.SaveChanges();

            TempData["Successful"] = "Data Saved Successsfully!";
            isValid = true;

            return Json (new { isValid });
        }
        public IActionResult SCheckScheduleName(string inputValue) //This method is called by the Jquery script in the CreateNewSchedule view to check if the category name
                                                                   //already exists in database without refreshing the whole page.
        {
            bool isValid;
            string checkForWhitespace = @"\s";

            bool whitespaceDedected = Regex.IsMatch(inputValue, checkForWhitespace);

            var checkScheduleName = _db.Schedules.FirstOrDefault(x => x.ScheduleName == inputValue);//checks if the value of inputValue exists in the database and returns the name if it exists.


            if (checkScheduleName == null && inputValue != null && !whitespaceDedected)
            {
                isValid = true;
                _scheduleModel!.ScheduleName = inputValue;
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
        public IActionResult SCheckDataPriorSaving(string selectedSchedule, string newSchName, string monHrs, string tueHrs, string wedHrs, string thurHrs, string friHrs, string satHrs, string sunHrs)
        {

            var obj = _db.Schedules.FirstOrDefault(x => x.ScheduleName == newSchName);//Check if the new schedule name already exists in the database.

            string checkForWhitespace = @"\s"; //Regex expression which checks for a whitespace in a string,
            string checkHoursFormat = "^[0-9]+$";//Regex expression which checks if a string contains only numbers without whitespaces.
            bool correctNumberFormat;
            bool whitespaceDetected = false;
            string error = "Orange";
            string noError = "Green";

            List<string> errorsList = new List<string>();
            List<string> hoursList = new List<string>() { monHrs, tueHrs, wedHrs, thurHrs, friHrs, satHrs, sunHrs };

            int errors = 0;

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
            else if (obj != null && newSchName!=selectedSchedule)
            {
                errors++;
                errorsList.Add(error);
            }
            else if(obj!=null && obj!.ScheduleName==selectedSchedule)
            {
                errorsList.Add(noError);
            }
            else if (!whitespaceDetected && obj == null && newSchName != null)
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