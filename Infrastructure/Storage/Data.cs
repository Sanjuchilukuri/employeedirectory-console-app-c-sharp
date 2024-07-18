namespace Infrastructure.Models
{
    public class Data
    {
        public string? EmployeeSequenceID { get; set; }

        public List<Employee>? Employees { get; set; }

        public Dictionary<string,List<string>>? Departments{ get; set; }
        
    }
}