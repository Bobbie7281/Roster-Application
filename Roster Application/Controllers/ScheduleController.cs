using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;

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
        public IActionResult ScheduleOptions() 
        {
            return View();
        }
        public IActionResult CreateNewSchedule()
        {
            return View();
        }
        public IActionResult EditExistingSchedule()
        {
            return View();
        }
    }
}
