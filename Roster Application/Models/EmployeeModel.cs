using Roster_Application.Models.Models_Interface;
using System.ComponentModel.DataAnnotations;

namespace Roster_Application.Models
{
    public class EmployeeModel : IEmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string ?EmployeeName { get; set; }
        [Required]
        public int EmployeeAddress { get; set; }
        [Required]
        public int EmployeeContactNumber { get; set; }
        [Required]
        public int EmployeeEmail { get; set; }
        [Required]
        public int EmployeeCategory { get; set; }
    }
}
