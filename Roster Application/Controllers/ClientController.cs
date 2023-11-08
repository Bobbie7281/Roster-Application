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
                if (!whitespaceDedected ) 
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
            var scheduleList= _db.Schedules.ToList();
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
        public IActionResult SCheckDataPriorSaving(string clientName, string address, string contactNum, string schedule, string category, int totalHours)
        {
            //check is address field conatins data
            //check if contact number contains only numbers.
            //check is a schedule was selected.
            //check if s category was selected.
            //upon schedule selection, total hours field should contain the total hours in the selected schedule.

            throw new NotImplementedException();
        }


    }
}
