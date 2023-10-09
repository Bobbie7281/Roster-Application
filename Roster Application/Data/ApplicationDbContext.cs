using Microsoft.EntityFrameworkCore;
using Roster_Application.Models;

namespace Roster_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ClientModel>Clients { get; set; }
        public DbSet<ScheduleModel> Schedules { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
       
    }
  
}
