using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApplication.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int? EmployeeId { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? DepartmentId { get; set; }
        public string? Details { get; set; }
        public decimal? Experience { get; set; }        
        public Department? Department { get; set; }
        public ICollection<Projects>? Projects { get; set; }
        public ICollection<Skills>? Skills { get; set; }
    }
}
