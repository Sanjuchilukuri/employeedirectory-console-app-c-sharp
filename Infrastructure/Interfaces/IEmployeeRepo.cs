using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface IEmployeeRepo : IBaseRepo
    {
        public string GetEmployeeSequenceID();

        public void UpdateEmployeeSequenceId();

        public Employee GetEmployeeById(string Id);

        public bool SaveEmployee(Employee newEmployee);

        public bool deleteEmployee(Employee employee);

        public List<Employee> GetAllEmployees();
    }
}