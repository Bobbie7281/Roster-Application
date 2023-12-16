using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Roster_Application.Models.Models_Interface
{
    public interface IClientModel
    {
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientAddress { get; set; }
        public string? ClientContactDetails { get; set; }
        public int? CatID { get; set; }
        public CategoryModel? CategoryId { get; set; }
        public int Schedule { get; set; }
        public ScheduleModel? ScheduleId { get; set; }
        public int TotalHours { get; set; }
    }
}
