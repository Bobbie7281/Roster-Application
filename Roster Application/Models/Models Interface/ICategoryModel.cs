using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Roster_Application.Models.Models_Interface
{
    public interface ICategoryModel
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
