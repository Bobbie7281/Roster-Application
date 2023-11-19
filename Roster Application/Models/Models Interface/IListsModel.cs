﻿namespace Roster_Application.Models.Models_Interface
{
    public interface IListsModel
    {
        public List<ClientModel>? ClientList { get; set; }
        public List<ScheduleModel>? ScheduleList { get; set; }
        public List<CategoryModel>? CategoryList { get; set; }
    }
}