﻿using Microsoft.AspNetCore.Mvc;
using Roster_Application.Data;
using Roster_Application.Models.Models_Interface;

namespace Roster_Application.Controllers
{
    public class RosterController : Controller
    {
        ApplicationDbContext _db;
        ICategoryModel? _categoryModel;
        IClientModel? _clientModel;
        IEmployeeModel? _employeeModel;
        IScheduleModel? _scheduleModel;
        IListsModel? _listsModel;
        public RosterController(ApplicationDbContext db, ICategoryModel categoryModel, IClientModel clientModel, IEmployeeModel employeeModel, IScheduleModel scheduleModel, IListsModel listsModel)
        {
            _db = db;
            _clientModel = clientModel;
            _employeeModel = employeeModel;
            _scheduleModel = scheduleModel;
            _categoryModel = categoryModel;
            _listsModel = listsModel;
        }
        [HttpPost]
        public IActionResult RosterOptions()
        {
            return View();
        }

        public IActionResult CreateRoster()
        {
            _listsModel!.ClientList = _db.Clients.ToList();
            
            return View(_listsModel);
        }
    }
}
