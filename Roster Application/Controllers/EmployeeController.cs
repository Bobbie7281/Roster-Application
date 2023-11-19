using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            _listsModel!.EmployeeList= _db.Employees.ToList();
            _listsModel!.CategoryList= _db.Categories.ToList();
            return View(_listsModel);
        }
        [HttpPost]
        public IActionResult SEditEmployeeDetails(string categoryName, string selectedName, List<string> empData) 
        {
            bool isValid = false;
            var employeeObj = _db.Employees.FirstOrDefault(x => x.EmployeeName == selectedName);
            var categoryObj = _db.Categories.FirstOrDefault(x=> x.CategoryName == categoryName);

            employeeObj!.EmployeeName = empData[0];
            employeeObj!.EmployeeSurname= empData[1];
            employeeObj!.EmployeeAddress = empData[2];
            employeeObj!.EmployeeContactNumber= empData[3];
            employeeObj!.EmployeeEmail= empData[4];
            employeeObj!.CategoryID = categoryObj!.CategoryId;

            _db.Employees.Update(employeeObj);
            _db.SaveChanges();
            isValid = true;
            TempData["Successful"] = "Data Saved Successfully.";


            return Json(new { isValid });
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
        [HttpPost]
        public IActionResult SGetData(string EmployeeName)
        {
            var employeeDetails = _db.Employees.FirstOrDefault(x => x.EmployeeName == EmployeeName);
            var categoryDetails = _db.Categories.Find(employeeDetails!.CategoryID);

            List<string> empData = new List<string>();

            if(employeeDetails!.EmployeeName!= null)
            {
                empData.Add(employeeDetails!.EmployeeName);
            }
            if (employeeDetails!.EmployeeSurname != null)
            {
                empData.Add(employeeDetails!.EmployeeSurname);
            }
            if (employeeDetails!.EmployeeAddress != null)
            {
                empData.Add(employeeDetails!.EmployeeAddress);
            }
            if (employeeDetails!.EmployeeContactNumber != null)
            {
                empData.Add(employeeDetails!.EmployeeContactNumber);
            }
            if (employeeDetails!.EmployeeEmail != null)
            {
                empData.Add(employeeDetails!.EmployeeEmail);
            }
            if (categoryDetails!.CategoryName!=null)
            {
                empData.Add(categoryDetails!.CategoryName);
            }

            return Json(empData);
        }
    }
}
