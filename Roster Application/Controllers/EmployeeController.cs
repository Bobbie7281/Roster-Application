using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;

namespace Roster_Application.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext _db;
        ICategoryModel? _categoryModel;
        IClientModel? _clientModel;
        IEmployeeModel? _employeeModel;
        IScheduleModel? _scheduleModel;
        public EmployeeController(ApplicationDbContext db, ICategoryModel categoryModel, IClientModel clientModel, IEmployeeModel employeeModel, IScheduleModel scheduleModel)
        {
            _db = db;
            _clientModel = clientModel;
            _employeeModel = employeeModel;
            _scheduleModel = scheduleModel;
            _categoryModel = categoryModel;
        }
        [HttpPost]
        public IActionResult EmployeeOptions() 
        {
            return View();
        }
        public IActionResult CreateNewEmployee()
        {
            return View();
        }
        public IActionResult EditExistingEmployee()
        {
            return View();
        }
    }
}
