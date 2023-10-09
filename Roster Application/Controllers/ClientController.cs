using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;
using System.Reflection.Metadata.Ecma335;

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


    }
}
