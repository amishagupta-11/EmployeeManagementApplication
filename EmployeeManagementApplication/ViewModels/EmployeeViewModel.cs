namespace EmployeeManagementApplication.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }
        public List<string>? ProjectNames { get; set; }
        public List<string>? SkillNames { get; set; }
    }

}
