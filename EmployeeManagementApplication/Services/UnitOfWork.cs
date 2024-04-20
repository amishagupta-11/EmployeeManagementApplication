using EmployeeManagementApplication.Data;
using EmployeeManagementApplication.Models;
using EmployeeManagementApplication.Respository;


namespace EmployeeManagementApplication.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementContext _context;

        public UnitOfWork(EmployeeManagementContext context)
        {
            _context = context;            
        }

        public IGenericRepository<EmployeeDetails> EmployeeRepository => new GenericRepository<EmployeeDetails>(_context);
        public IGenericRepository<Department> DepartmentRepository => new GenericRepository<Department>(_context);
        public IGenericRepository<Projects> ProjectRepository => new GenericRepository<Projects>(_context);
        public IGenericRepository<Skills> SkillRepository => new GenericRepository<Skills>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
