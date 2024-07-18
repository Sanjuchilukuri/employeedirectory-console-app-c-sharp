using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repos
{
    public class DepartmentsAndRolesRepo : BaseRepo, IDepartmentsAndRolesRepo
    {
        public void AddRole(string newRole, string department)
        {
            Data jsonFile = ReadJsonFile();
            jsonFile?.Departments?[department].Add(newRole);
            WriteJsonFile(jsonFile!);
        }

        public List<string> GetDepartments()
        {
            Data jsonFile = ReadJsonFile();
            List<string> keyList = new List<string>(jsonFile.Departments!.Keys);
            return keyList;
        }

        public List<string> GetAllRoles()
        {
            Data jsonFile = ReadJsonFile();
            List<List<string>> roles = new List<List<string>>(jsonFile.Departments!.Values);
            List<string> allRoles = roles.SelectMany(x => x).ToList();
            allRoles = allRoles.Distinct().ToList();
            return allRoles;
        }

        public List<string> GetRoles(string department)
        {
            List<string> allRoles;
            Data jsonFile = ReadJsonFile();
            allRoles = jsonFile?.Departments?[department]!;
            return allRoles;
        }
    }


}