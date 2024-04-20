using EmployeeManagementApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApplication.Data
{
    /// <summary>
    /// Context class for the tables
    /// </summary>
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
                : base(options)
        {

        }
        public DbSet<EmployeeDetails>? Employees { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Projects>? Projects { get; set; }
        public DbSet<Skills>? Skills { get; set; }


    }
}

