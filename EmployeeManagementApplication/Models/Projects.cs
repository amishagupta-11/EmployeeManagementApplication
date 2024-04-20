using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApplication.Models
{
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string? ProjectName { get; set; }
        public int? DepartmentId { get; set; }        
        public Department? Department{ get; set; }
        public ICollection<EmployeeDetails>? Employees { get; set; }
    }
}
