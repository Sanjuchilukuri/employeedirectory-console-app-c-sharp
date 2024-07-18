using Application.Interfaces;
using Infrastructure.Models;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class EmployeeServices : CommonServices, IEmployeeServices
    {
        private readonly IEmployeeRepo _employeeRepo ;

        public EmployeeServices(IEmployeeRepo employeeRepo, IDepartmentsAndRolesRepo departmentsAndRolesRepo): base(departmentsAndRolesRepo) 
        {
            _employeeRepo = employeeRepo;
        }

        public bool AddEmployee(Employee newEmployee)
        {
            if(newEmployee.EmpId == null )
            {
                GenerateEmpID();
            }
            else
            {
                newEmployee.EmpId = newEmployee.EmpId;
            }
            return _employeeRepo.SaveEmployee(newEmployee);
        }

        private string GenerateEmpID()
        {
            string empId = "TZ" + _employeeRepo.GetEmployeeSequenceID();
            _employeeRepo.UpdateEmployeeSequenceId();
            return empId;
        }

        public bool DeleteEmployee(Employee employee)
        {
            return _employeeRepo.deleteEmployee(employee);
        }

        public Employee GetEmployee(string id)
        {
            return _employeeRepo.GetEmployeeById(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepo.GetAllEmployees();
        }
    }
}