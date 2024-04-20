using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApplication.Models
{
    public class Skills
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        public string? SkillName { get; set; }
        
        public int? DepartmentId { get; set; }

        [Required]
        public Department? Department { get; set; }

        public ICollection<EmployeeDetails>? Employees { get; set; }
    }


}

