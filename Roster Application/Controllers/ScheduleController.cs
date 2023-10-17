using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models;
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
        public IActionResult CheckScheduleName(string inputValue) //This method is called by the Jquery script to check is the category name
                                                                  //already exists in database without refreshing the whole page.
        {
            bool isValid;

            var checkCategoryName = _db.Categories.FirstOrDefault(x => x.CategoryName == inputValue);//checks if the value of inputValue exists in the database and returns the name if it exists.

            if (checkCategoryName == null)
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
        public IActionResult EditExistingSchedule()
        {
            return View();
        }
    }
}
