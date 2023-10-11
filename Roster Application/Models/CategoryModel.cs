using Roster_Application.Models.Models_Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roster_Application.Models
{
    public class CategoryModel : ICategoryModel
    {
        [Key]
        [Required]
        [DisplayName ("Category Id:")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName ("Provide a Category Name: ")]
        public string ?CategoryName { get; set; }

    } 
}
