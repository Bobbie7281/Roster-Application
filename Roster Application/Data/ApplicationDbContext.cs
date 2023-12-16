using Microsoft.EntityFrameworkCore;
using Roster_Application.Models;

namespace Roster_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ClientModel>Clients { get; set; }
        public DbSet<ScheduleModel> Schedules { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        //public DbSet<EmployeesModel> Employee { get; set; } //not in use

        public DbSet<EmpModel> Employees { get; set; }
        //public DbSet<EmployeesModel> Employees { get; set; }

    }
  
}
