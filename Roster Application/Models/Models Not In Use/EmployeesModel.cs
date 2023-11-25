using Roster_Application.Models.Models_Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roster_Application.Models
{
    public class EmployeesModel : IEmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("Employee Name:")]
        public string? EmployeeName { get; set; }
        [Required]
        [DisplayName("Surname:")]
        public string? EmployeeSurname { get; set; }
        [Required]
        [DisplayName("Employee Address:")]
        public string? EmployeeAddress { get; set; }
        [Required]
        [DisplayName("Employee Contact Number:")]

        public string? EmployeeContactNumber { get; set; }
        [Required]
        [DisplayName("Employee Email Address:")]

        public string? EmployeeEmail { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        public CategoryModel? CategoryId { get; set; }
    }
}
