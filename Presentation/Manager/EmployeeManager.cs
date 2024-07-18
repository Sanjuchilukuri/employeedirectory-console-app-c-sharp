using Presentation.Error;
using Presentation.Interfaces;
using Presentation.UserInputManagement;
using Infrastructure.Models;
using Application.Interfaces;
using System.Reflection;

namespace Presentation.Manager
{
    public class EmployeeManager : IEmployeeMenu
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeManager(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        public void AddEmployee()
        {
            Employee newEmployee = GatherEmployeeDetails();
            if (_employeeServices.AddEmployee(newEmployee))
            {
                _employeeServices.AddEmployee(newEmployee);
                Console.WriteLine($"\n Your EmpID is {newEmployee.EmpId} \n");
            }
            else
            {
                ErrorMessage.OperationFailed();
            }
            // Interactions.Wait();
        }

        private Employee GatherEmployeeDetails()
        {
            Employee emp = new Employee();

            Console.WriteLine("====================AddEmployee====================");

            Console.Write("\n Enter First Name*           : ");
            emp.FirstName = InputReader.GetName("Mandatory");

            Console.Write("\n Enter Last Name*            : ");
            emp.LastName = InputReader.GetName("Mandatory");

            Console.Write("\n Enter Date Of Birth         : ");
            emp.DateOfBirth = InputReader.GetDate("NotMandatory");

            Console.Write("\n Enter 10 Digits PhoneNumber : ");
            emp.PhoneNumber = InputReader.GetPhno();

            Console.Write("\n Enter Email*                : ");
            emp.Email = InputReader.GetMail();

            Console.Write("\n Enter joining Date*         : ");
            emp.JoiningDate = InputReader.GetDate("Mandatory");

            Console.Write("\n Enter Location*             : ");
            emp.Location = InputReader.GetName("Mandatory");

            Console.WriteLine("\n Enter the Department NO*: ");
            List<string> departments = _employeeServices.GetDepartments();
            printList(departments);
            Console.Write("\n >");
            int departmentIndex = InputReader.GetOption(departments.Count);
            emp.Department = departments[departmentIndex - 1];

            Console.WriteLine("\n Enter the Role NO*: ");
            List<string> roles = _employeeServices.GetRoles(emp.Department);
            printList(roles);
            Console.Write("\n >");
            int rolesIndex = InputReader.GetOption(roles.Count);
            emp.Role = roles[rolesIndex - 1];

            Console.Write("\n Assign a Manager            : ");
            emp.AssignManager = InputReader.GetName("NotMandatory");

            Console.Write("\n Assign a Project            : ");
            emp.Project = InputReader.GetName("NotMandatory");

            return emp;
        }

        private void printList(List<string> optionsList)
        {
            for (int i = 0; i < optionsList.Count; i++)
            {
                Console.Write($" {i + 1}) {optionsList[i]}\t");
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("\nEnter the EmpId you want to delete > ");
            string deleteEmpId = InputReader.GetEmpID();
            Employee emp = _employeeServices.GetEmployee(deleteEmpId);
            if (emp != null)
            {
                if (_employeeServices.DeleteEmployee(emp))
                {
                    Console.WriteLine($"{emp.EmpId} Was Deleted Successfully");
                }
                else
                {
                    ErrorMessage.OperationFailed();
                }
            }
            else
            {
                ErrorMessage.RecordNotAvailable(deleteEmpId);
            }
            // Interactions.Wait();
        }

        public void DisplayEmployees()
        {
            List<Employee> allEmployees = _employeeServices.GetEmployees();
            if (allEmployees.Count > 0)
            {
                PrintAllEmployees(allEmployees);
            }
            else
            {
                ErrorMessage.DataNotAvailable();
            }
            // Interactions.Wait();
        }

        public void PrintAllEmployees(List<Employee> allEmployees)
        {
            for (int i = 0; i < 126; i++) Console.Write("-");
            Console.WriteLine();
            foreach (var properties in typeof(Employee).GetProperties())
            {
                if (IsRequired(properties.Name))
                {
                    Console.Write($"|{properties.Name.PadRight(13)}");
                }
            }
            Console.Write("|");
            Console.WriteLine();
            for (int i = 0; i < 126; i++) Console.Write("-");
            Console.WriteLine();


            foreach (var employee in allEmployees)
            {
                foreach (var properties in employee.GetType().GetProperties())
                {
                    if (IsRequired(properties.Name))
                    {
                        string value = properties.GetValue(employee)?.ToString() ?? "";
                        if (value.Length > 12)
                        {
                            value = value.Substring(0, 9) + "...";
                        }
                        Console.Write($"|{value,-13}");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
                for (int i = 0; i < 126; i++) Console.Write("-");
                Console.WriteLine();
            }
        }

        private bool IsRequired(string name)
        {
            List<string> notRequiredFields = ["DateOfBirth", "PhoneNumber", "Email"];
            return !notRequiredFields.Contains(name);
        }

        public void EditEmployee()
        {
            Console.Write("\nEnter the EmpId you want to Edit > ");
            string editEmpId = InputReader.GetEmpID();
            Employee emp = _employeeServices.GetEmployee(editEmpId);
            if (emp != null)
            {
                DisplayEmployeeFields(emp);
            }
            else
            {
                ErrorMessage.RecordNotAvailable(editEmpId);
            }
            // Interactions.Wait();
        }

        public void DisplayEmployeeFields(Employee employee)
        {
            int j = 0;
            Console.WriteLine("\nChoose The Field From Below To Edit ");
            PropertyInfo[] properties = employee.GetType().GetProperties();
            for (j = 1; j < properties.Length; j++)
            {
                Console.WriteLine($"{j} {properties[j].Name}");
            }
            Console.WriteLine($"{j} Back");
            EditEmployeeFields(employee, properties, j);
        }

        private void EditEmployeeFields(Employee employee, PropertyInfo[] properties, int exitIndex)
        {
            bool displayFields = true;
            while (displayFields)
            {
                Console.Write($"Enter Field NO You Want TO Edit \n\tOR\nEnter {exitIndex} to Go back \n>");
                int selectedInput = InputReader.GetEditEmployeeInput(exitIndex);
                Console.WriteLine("Enter Your Input");

                if (selectedInput == exitIndex)
                {
                    displayFields = false;
                    continue;
                }

                Console.Write($"{properties[selectedInput].Name} : ");

                string field = properties[selectedInput].Name;
                if (field == "DateOfBirth" || field == "JoiningDate")
                {
                    string newDate = InputReader.GetDate("Mandatory")!;
                    properties[selectedInput].SetValue(employee, newDate);
                }
                else if (field == "PhoneNumber")
                {
                    string newPhNo = InputReader.GetPhno()!;
                    properties[selectedInput].SetValue(employee, newPhNo);
                }
                else if (field == "Email")
                {
                    string newMail = InputReader.GetMail()!;
                    properties[selectedInput].SetValue(employee, newMail);
                }
                else
                {
                    if (field == "Department")
                    {
                        List<string> departments = _employeeServices.GetDepartments();
                        printList(departments);
                        Console.Write("\n>");
                        int departmentIndex = InputReader.GetOption(departments.Count);
                        properties[selectedInput].SetValue(employee, departments[departmentIndex - 1]);
                        
                    }
                    else if (field == "Role")
                    {
                        List<string> roles = _employeeServices.GetRoles(employee.Department!);
                        printList(roles);
                        Console.Write("\n>");
                        int rolesIndex = InputReader.GetOption(roles.Count);
                        properties[selectedInput].SetValue(employee, roles[rolesIndex - 1]);
                    }
                    else if (field == "AssignManager" || field == "Project")
                    {
                        string newValue = InputReader.GetName("NotMandatory")!;
                        properties[selectedInput].SetValue(employee, newValue);
                    }
                    else
                    {
                        string newValue = InputReader.GetName("Mandatory")!;
                        properties[selectedInput].SetValue(employee, newValue);
                    }
                }

                // unit of work
                _employeeServices.DeleteEmployee(employee);
                _employeeServices.AddEmployee(employee);
                Console.WriteLine($"\n{properties[selectedInput].Name} was Updated Successfully\n");
                // Interactions.wait();
            }
        }

        public void ViewEmployee()
        {
            Console.Write("\nEnter the EmpId you want to View > ");
            string viewEmpId = InputReader.GetEmpID();
            Employee employee = _employeeServices.GetEmployee(viewEmpId);
            if (employee != null)
            {
                foreach (var property in employee.GetType().GetProperties())
                {
                    Console.WriteLine($"{property.Name.PadRight(18)} : {property.GetValue(employee)}");
                }
            }
            else
            {
                ErrorMessage.RecordNotAvailable(viewEmpId);
            }
            // Interactions.Wait();
        }
    }
}