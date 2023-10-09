using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Roster_Application.Models.Models_Interface;
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
        public string ?ClientName { get; set; }

        [Required]
        public string ?ClientAddress { get; set; }

        [Required]
        public string ?ClientContactDetails { get; set; }

        [Required]
        public string ?CategoryName {  get; set; }

        [Required]
        [ForeignKey("ScheduleId")]
        public int ScheduleID { get; set; }
        public ScheduleModel ?ScheduleId { get; set; }

        [Required]
        public int TotalHours { get; set;}
   
    }
}
