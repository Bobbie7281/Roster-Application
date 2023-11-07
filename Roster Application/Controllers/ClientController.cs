using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;

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
        public IActionResult SCheckCheckClientName(string input)
        {
            bool isValid = false;

            var checkClientName = _db.Clients.FirstOrDefault(x => x.ClientName == input);

            if (checkClientName == null)
            {
                isValid = true;
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


    }
}
