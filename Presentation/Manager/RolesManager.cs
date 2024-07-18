using Presentation.Error;
using Presentation.Interfaces;
using Presentation.UserInputManagement;
using Application.Interfaces;

namespace Presentation.Manager
{
    public class RolesManager : IRolesMenu
    {
        private readonly IRolesServices _rolesServices ;

        public RolesManager(IRolesServices rolesServices)
        {
            _rolesServices = rolesServices;
        }

        public void AddRole()
        {
            bool displayAddRole = true;
            while (displayAddRole)
            {
                Console.Write("\nEnter The Role You Want* \n>");
                string newRole = InputReader.GetName("Mandatory")!;
                if (_rolesServices.IsRoleExists(newRole))
                {
                    Console.WriteLine($"{newRole} is already Existed");
                }
                else
                {
                    Console.Write("\nEnter the department* \n>");
                    List<string> departments = _rolesServices.GetDepartments();
                    printList(departments);
                    Console.Write("\n>");
                    int departmentIndex = InputReader.GetOption(departments.Count);
                    
                    Console.Write("\nEnter the description \n>");
                    string descriprion = InputReader.GetName("NotMandatory")!;

                    Console.Write("\nEnter the Location* \n>");
                    string location = InputReader.GetName("Mandatory")!;

                    _rolesServices.AddRole(newRole, departments[departmentIndex-1]);
                    Console.WriteLine($"{newRole} was Added!\n");

                }

                Console.Write("\nDo you want to Add Another Role(Y/N) \n>");
                char addAnotherRole = InputReader.GetCharInput();
                if (addAnotherRole == 'N')
                {
                    displayAddRole = false;
                }
            }
        }

        private void printList(List<string> optionsList)
        {
            for (int i = 0; i < optionsList.Count; i++)
            {
                Console.Write($" {i + 1}) {optionsList[i]}\t");
            }
        }

        public void DisplayRoles()
        {
            List<string> allRoles = _rolesServices.GetAllRoles();
            if (allRoles.Count > 0)
            {
                for (int _ = 0; _ < 22; _++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                for (int i = 0; i < allRoles.Count; i++)
                {
                    string value = allRoles[i];
                    if (value.Length > 14)
                    {
                        value = value.Substring(0, 11) + "...";
                    }
                    Console.WriteLine($"|  {i + 1}) {value,-15}|");
                    for (int _ = 0; _ < 22; _++) Console.Write("-");
                    Console.WriteLine();
                }
                // Interactions.wait();
            }
            else
            {
                ErrorMessage.DataNotAvailable();
            }
        }
    }
}