using System.ComponentModel.DataAnnotations;

namespace Roster_Application.Models.Models_Interface
{
    public interface IEmployeeModel
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int EmployeeAddress { get; set; }
        public int EmployeeContactNumber { get; set; }
        public int EmployeeEmail { get; set; }
        public int EmployeeCategory { get; set; }
    }
}
