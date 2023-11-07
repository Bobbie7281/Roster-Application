using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Roster_Application.Models.Models_Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Roster_Application.Models
{
    public class ClientModel : IClientModel
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [DisplayName ("Client Name:")]
        public string ?ClientName { get; set; }

        [Required]
        [DisplayName ("Address:")]
        public string ?ClientAddress { get; set; }

        [Required]
        [DisplayName ("Contact Number:")]
        public string ?ClientContactDetails { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        [DisplayName ("Category:")]
        public int ?CategoryID {  get; set; }
        public CategoryModel ?CategoryId { get; set; }

        [Required]
        [ForeignKey("ScheduleId")]
        [DisplayName("Schedule:")]
        public int ScheduleID { get; set; }
        public ScheduleModel ?ScheduleId { get; set; }

        [Required]
        [DisplayName("Total Weekly Hours:")]
        public int TotalHours { get; set;}
   
    }
}
