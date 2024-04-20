using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string? DepartmentName { get; set; }       
        public ICollection<EmployeeDetails>? Employees { get; set; }
        public ICollection<Skills>? Skills { get; set; }
    }
}
