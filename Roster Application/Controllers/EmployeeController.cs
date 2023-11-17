using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models;
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
            _listsModel!.CategoryList = _db.Categories.ToList();
            return View(_listsModel);
        }
        public IActionResult EditExistingEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SCheckDataPriorSaving(List<string> empData)
        {
            string error = "Orange";
            string noError = "Green";
            List<string> errorList = new();

            int errors = 0;

            foreach (var data in empData)
            {
                if (data != null)
                {
                    errorList.Add(noError);
                }
                else
                {
                    errors++;
                    errorList.Add(error);
                }
            }

            errorList.Add(errors.ToString());
            return Json(errorList);
        }
        [HttpPost]
        public IActionResult SSaveEmployeeDetails(List<string> empData)
        {
            bool isValid = false;

            var category = _db.Categories.FirstOrDefault(x => x.CategoryName == empData[5]);

            try
            {
                _employeeModel!.EmployeeName = empData[0];
                _employeeModel!.EmployeeSurname = empData[1];
                _employeeModel!.EmployeeAddress = empData[2];
                _employeeModel!.EmployeeContactNumber = empData[3];
                _employeeModel!.EmployeeEmail = empData[4];
                _employeeModel!.CategoryID = category!.CategoryId;

                _db.Employees.Add((EmployeeModel)_employeeModel);
                _db.SaveChanges();
                isValid = true;
                TempData["Successful"] = "Data Saved Successfully.";
            }
            catch (Exception ex) 
            {
                isValid = false;
                TempData["Unsuccessful"] = "Data note saved due to the following error:/n/n" + ex.Message;
            }
            
            return Json(new { isValid });
        }
    }
}
