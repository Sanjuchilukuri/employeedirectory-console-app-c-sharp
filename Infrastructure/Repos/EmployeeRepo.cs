using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repos
{
    public class EmployeeRepo : BaseRepo, IEmployeeRepo
    {
        public string GetEmployeeSequenceID()
        {
            return ReadJsonFile()?.EmployeeSequenceID!;
        }

        public void UpdateEmployeeSequenceId()
        {
            Data jsonFile = ReadJsonFile();
            int CurrentId = Convert.ToInt32(jsonFile.EmployeeSequenceID);
            jsonFile.EmployeeSequenceID = (1 + CurrentId).ToString();
            WriteJsonFile(jsonFile);
        }

        public Employee GetEmployeeById(string Id)
        {
            Data jsonFile = ReadJsonFile();
            return jsonFile.Employees!.SingleOrDefault(employee => employee.EmpId == Id)!;
        }

        public bool SaveEmployee(Employee newEmployee)
        {
            Data jsonFile = ReadJsonFile();
            jsonFile.Employees?.Add(newEmployee);
            WriteJsonFile(jsonFile);
            return true;
        }

        public bool deleteEmployee(Employee employee)
        {
            string empId = employee.EmpId!;
            Data jsonFile = ReadJsonFile();
            jsonFile.Employees?.Remove(jsonFile.Employees.SingleOrDefault(emp => emp.EmpId == empId)!);
            WriteJsonFile(jsonFile);
            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return ReadJsonFile().Employees!;
        }
    }
}