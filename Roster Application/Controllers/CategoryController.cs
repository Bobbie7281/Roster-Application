using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models;
using Roster_Application.Models.Models_Interface;

namespace Roster_Application.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _db;
        ICategoryModel? _categoryModel;
        IClientModel? _clientModel;
        IEmployeeModel? _employeeModel;
        IScheduleModel? _scheduleModel;

        public CategoryController(ApplicationDbContext db, ICategoryModel categoryModel, IClientModel clientModel, IEmployeeModel employeeModel, IScheduleModel scheduleModel)
        {
            _db = db;
            _clientModel = clientModel;
            _employeeModel = employeeModel;
            _scheduleModel = scheduleModel;
            _categoryModel = categoryModel;
        }

        public IActionResult CategoryOptions()
        {
            return View();
        }
        public IActionResult CreateNewCategory()
        {
            return View();
        }
        [HttpPost, ActionName("Create Category")]
        public IActionResult CreateNewCategory(CategoryModel obj)
        {
            obj.CategoryName = Request.Form["CategoryName"].ToString();//Get the category name from the input field of the view.

            if (obj.CategoryName == "")
            {
                TempData["Unsuccessful"] = "Name for new category cannot be blank. Please provide a name.";
            }
            else
            {
                var duplicateCategoryNames = _db.Categories.ToList().Find(x => x.CategoryName == obj.CategoryName);//Check if category name already exist in the database

                if (duplicateCategoryNames == null) //Category will only be saved if the name doesn't exist in the database.
                {
                    _db.Add(obj);
                    _db.SaveChanges();
                    TempData["Successful"] = "Data saved successfully! \"" + obj.CategoryName.ToString() + "\" was added to the category list.";
                }
                else
                {
                    TempData["Unsuccessful"] = "Category not saved because \"" + obj.CategoryName.ToString() + "\" already exists in the database!!";
                }
            }

            return RedirectToAction("CreateNewCategory", "Category");
        }

        public IActionResult EditExistingCategory()
        {
            var listOfCategories = _db.Categories.ToList();//Get all the categories from the database

            return View(listOfCategories);//pass the category list to the view
        }
        [HttpPost]
        public IActionResult AddNewCategoryName()
        {
            _categoryModel = _db.Categories.FirstOrDefault(x => x.CategoryName == Request.Form["editCategory"].ToString());//Get the selected Category Name from the form

            string updatedName = Request.Form["UpdatdCategoryName"].ToString(); //Get the updated category name from the form.

            var checkNewName = _db.Categories.FirstOrDefault(x => x.CategoryName == updatedName.ToString());

            if (checkNewName == null && updatedName != "")
            {
                _categoryModel!.CategoryName = updatedName;//change the category name with the new name (updatedName).

                _db.Categories.Update((CategoryModel)_categoryModel); //Update the database.

                _db.SaveChanges();//Save chnages into the database.
                TempData["Successful"] = "Category name changed successfully!"; //Display successful message
            }
            else if (checkNewName == null && updatedName == "")
            {
                //Display unsuccessful message when edited name is left blank
                TempData["Unsuccessful"] = "Category name cannot be blank. Please type in a new name for the selected category";
            }
            else
            {
                //Display unsuccessful message when edited name already exist in the database
                TempData["Unsuccessful"] = "Category name \"" + updatedName + "\" already exists in the database. Please choose another name!";
            }

            return RedirectToAction("EditExistingCategory", "Category");
        }
        public IActionResult ListOfClientsPerCategory()
        {
            return View();
        }
    }
}
