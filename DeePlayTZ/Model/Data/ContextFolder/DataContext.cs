using DeePlayTZ.Model.Data.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DeePlayTZ.Model.Data.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  DataBase=DeeplayDataBaseMSSQL;
                  Trusted_Connection=True;"
                );
        }
    }
}
