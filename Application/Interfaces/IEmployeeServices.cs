using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IEmployeeServices : ICommonServices
    {
        public bool AddEmployee(Employee emp);

        public bool DeleteEmployee(Employee emp);

        public List<Employee> GetEmployees();
      
        public Employee GetEmployee(string id); 
    }
}
