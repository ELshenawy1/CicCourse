using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class CompContext : DbContext
    {
        public CompContext()
        {
            
        }
        public CompContext(DbContextOptions options)  : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MyComp;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
