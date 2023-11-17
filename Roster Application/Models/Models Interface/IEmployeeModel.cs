using System.ComponentModel.DataAnnotations;

namespace Roster_Application.Models.Models_Interface
{
    public interface IEmployeeModel
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeSurname {  get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeContactNumber { get; set; }
        public string EmployeeEmail { get; set; }
        public int CategoryID { get; set; }
        public CategoryModel? CategoryId { get; set; }
    }
}
