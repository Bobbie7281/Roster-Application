using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;
using System.Text.RegularExpressions;

namespace Roster_Application.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext _db;
        ICategoryModel? _categoryModel;
        IClientModel? _clientModel;
        IEmployeeModel? _employeeModel;
        IScheduleModel? _scheduleModel;
        IListsModel? _listsModel;
        public EmployeeController(ApplicationDbContext db, ICategoryModel categoryModel, IClientModel clientModel, 
            IEmployeeModel employeeModel, IScheduleModel scheduleModel, IListsModel listsModel)
        {
            _db = db;
            _clientModel = clientModel;
            _employeeModel = employeeModel;
            _scheduleModel = scheduleModel;
            _listsModel = listsModel;
            _categoryModel = categoryModel;
        }
        [HttpPost]
        public IActionResult EmployeeOptions() 
        {
            return View();
        }
        public IActionResult CreateNewEmployee()
        {
            _listsModel!.CategoryList=_db.Categories.ToList();
            return View(_listsModel);
        }
        public IActionResult EditExistingEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SCheckDataPriorSaving(string ename, string esurname , string eaddress, string econtact, string eemailAddress, string ecategory) 
        {
            string error = "Orange";
            string noError = "Green";

            int errors = 0;

            
            throw new NotImplementedException();
        }
    }
}
