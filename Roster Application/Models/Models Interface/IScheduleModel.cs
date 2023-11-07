using System.ComponentModel.DataAnnotations;

namespace Roster_Application.Models.Models_Interface
{
    public interface IScheduleModel
    {
        public int ScheduleId { get; set; }
        public string? ScheduleName { get; set; }
        public int ScheduleMonTotHours { get; set; }
        public int ScheduleTueTotHours { get; set; }
        public int ScheduleWedTotHours { get; set; }
        public int ScheduleThurTotHours { get; set; }
        public int ScheduleFriTotHours { get; set; }
        public int ScheduleSatTotHours { get; set; }
        public int ScheduleSunTotHours { get; set; }
        public int ScheduleTotalHours { get; set; }
    }
}
