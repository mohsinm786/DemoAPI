using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
