using Roster_Application.Models.Models_Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Roster_Application.Models
{
    public class ScheduleModel : IScheduleModel
    {
        [Key]
        [Required]
        public int ScheduleId { get; set; }
        [Required]
        [DisplayName("Schedule Name:")]
        public string? ScheduleName { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Only numeric characters are allowed.")]
        [DisplayName("Mon Hrs:")]
        public int ScheduleMonTotHours { get; set; }
        [Required]
        [DisplayName("Tue Hrs:")]
        public int ScheduleTueTotHours { get; set;}
        [Required]
        [DisplayName("Wed Hrs:")]
        public int ScheduleWedTotHours { get; set;}
        [Required]
        [DisplayName("Thur Hrs:")]
        public int ScheduleThurTotHours { get; set;}
        [Required]
        [DisplayName("Fri Hrs:")]
        public int ScheduleFriTotHours { get; set; }
        [Required]
        [DisplayName("Sat Hrs:")]
        public int ScheduleSatTotHours { get; set; }
        [Required]
        [DisplayName("Sun Hrs:")]
        public int ScheduleSunTotHours { get; set; }
        [Required]
        [DisplayName ("Total Weekly Hours:")]
        public int ScheduleTotalHours {  get; set; }
            

    }
}
