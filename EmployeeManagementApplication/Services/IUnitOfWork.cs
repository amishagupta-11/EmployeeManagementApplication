using EmployeeManagementApplication.Models;
using EmployeeManagementApplication.Respository;

namespace EmployeeManagementApplication.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<EmployeeDetails> EmployeeRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        IGenericRepository<Projects> ProjectRepository { get; }
        IGenericRepository<Skills> SkillRepository { get; }
        void Save();
    }
}
