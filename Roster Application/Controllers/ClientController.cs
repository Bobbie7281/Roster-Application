using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;
using System.Text.RegularExpressions;

namespace Roster_Application.Controllers
{
    public class ClientController : Controller
    {
        ApplicationDbContext _db;
        ICategoryModel? _categoryModel;
        IClientModel? _clientModel;
        IEmployeeModel? _employeeModel;
        IScheduleModel? _scheduleModel;
        public ClientController(ApplicationDbContext db, ICategoryModel categoryModel, IClientModel clientModel, IEmployeeModel employeeModel, IScheduleModel scheduleModel)
        {
            _db = db;
            _clientModel = clientModel;
            _employeeModel = employeeModel;
            _scheduleModel = scheduleModel;
            _categoryModel = categoryModel;
        }

        public IActionResult ClientOptions()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }

        public IActionResult CreateNewClient()
        {
            return View();
        }

        public IActionResult EditExistingClient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SCheckClientName(string inputValue)
        {
            bool isValid;
            string checkForWhitespace = @"\s";

            bool whitespaceDedected = false;

            var checkClientName = _db.Clients.FirstOrDefault(x => x.ClientName == inputValue);//checks if the value of inputValue exists in the database and returns the name if it exists.


            if (checkClientName == null && inputValue != null)// && !whitespaceDedected)//If name does not exist in DB & name is not null & no whitespaces dedected
            {
                whitespaceDedected = Regex.IsMatch(inputValue, checkForWhitespace);
                if (!whitespaceDedected)
                {
                    isValid = true;
                    _clientModel!.ClientName = inputValue;
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
        [HttpGet]
        public IActionResult SGetAllSchedules()
        {
            var scheduleList = _db.Schedules.ToList();
            List<string> scheduleNames = new();

            foreach (var schedule in scheduleList)
            {
                if (schedule.ScheduleName != null)
                {
                    scheduleNames.Add(schedule.ScheduleName.ToString());
                }
            }
            return Json(scheduleNames);
        }
        [HttpGet]
        public IActionResult SGetAllCategories()
        {
            var categoryList = _db.Categories.ToList();
            List<string> categoryNames = new();

            foreach (var category in categoryList)
            {
                if (category.CategoryName != null)
                {
                    categoryNames.Add(category.CategoryName.ToString());
                }
            }
            return Json(categoryNames);
        }
        public IActionResult SCheckDataPriorSaving(bool editingCurrentClient, string selectedName, string clientName, string address, string contactNum, string schedule, string category, int totalHours)
        {
            
            var obj = _db.Clients.FirstOrDefault(x => x.ClientName == clientName);//Check if the new Client name already exists in the database.

            string checkForWhitespace = @"\s"; //Regex expression which checks for a whitespace in a string,
            List<string> FieldData = new() { address, contactNum, schedule, category };
            bool whitespaceDetected = false;
            string error = "Orange";
            string noError = "Green";

            List<string> errorsList = new List<string>();

            int errors = 0;

            if (editingCurrentClient)
            {
                if (clientName == null)
                {
                    errors++;
                    errorsList.Add(error);
                }
                else
                {
                    whitespaceDetected = Regex.IsMatch(clientName, checkForWhitespace);
                }


                if (whitespaceDetected)
                {
                    errors++;
                    errorsList.Add(error);
                }
                else if (obj != null && clientName != selectedName)
                {
                    errors++;
                    errorsList.Add(error);
                }
                else if (obj != null && obj!.ClientName == selectedName)
                {
                    errorsList.Add(noError);
                }
                else if (!whitespaceDetected && obj == null && clientName != null)
                {
                    errorsList.Add(noError);
                }
            }
            else
            {
                errorsList.Add(noError);

                foreach (string item in FieldData)
                {
                    if (item == null)
                    {
                        errors++;
                        errorsList.Add(error);
                    }
                    else
                    {
                        errorsList.Add(noError);
                    }
                }

            }


            errorsList.Add(errors.ToString());
            return Json(errorsList);
        }
        [HttpPost]
        public IActionResult SGetTotalHours(string scheduleName)
        {
            var scheduleObj = _db.Schedules.FirstOrDefault(x => x.ScheduleName == scheduleName);

            return Json(scheduleObj!.ScheduleTotalHours);
        }
        public IActionResult SCreateNewClient(string clientName, string address, string contactNum, string schedule, string category, int totalHours)
        {
            bool isValid = false;
            var scheduleObj = _db.Schedules.FirstOrDefault(x => x.ScheduleName == schedule);
            var categoryObj = _db.Categories.FirstOrDefault(x => x.CategoryName ==  category);

            _clientModel!.ClientName = clientName;
            _clientModel.ClientAddress = address;
            _clientModel.ClientContactDetails = contactNum;
            _clientModel.ScheduleID = scheduleObj!.ScheduleId;
            _clientModel.CategoryID = categoryObj!.CategoryId;
            _clientModel.TotalHours = totalHours;

            _db.Add(_clientModel);
            _db.SaveChanges();
            isValid = true;
            TempData["Successful"] = "New Client successfully saved.";

            return Json(new { isValid });
        }

    }
}
