using Roster_Application.Models.Models_Interface;
using System.Data.Common;

namespace Roster_Application.Models
{
    public class ListsModel : IListsModel
    {
       
        public List<ClientModel>? ClientList  { get; set; }
        public List<ScheduleModel>? ScheduleList { get; set; }
        public List<CategoryModel>? CategoryList { get; set; }
        public List<EmployeeModel>? EmployeeList { get; set; }
    }
}
