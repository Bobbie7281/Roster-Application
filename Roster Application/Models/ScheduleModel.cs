using Roster_Application.Models.Models_Interface;
using System.ComponentModel.DataAnnotations;

namespace Roster_Application.Models
{
    public class ScheduleModel : IScheduleModel
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public string ?ScheduleName { get; set; }
        [Required]
        public int ScheduleMonTotHours { get; set; }
        [Required]
        public int ScheduleTueTotHours { get; set;}
        [Required]
        public int ScheduleWedTotHours { get; set;}
        [Required]
        public int ScheduleThurTotHours { get; set;}
        [Required]
        public int ScheduleFriTotHours { get; set; }
        [Required]
        public int ScheduleSatTotHours { get; set; }
        [Required]
        public int ScheduleSunTotHours { get; set; }
            

    }
}
