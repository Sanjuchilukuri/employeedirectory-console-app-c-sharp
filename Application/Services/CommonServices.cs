using Application.Interfaces;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class CommonServices : ICommonServices
    {
        private readonly IDepartmentsAndRolesRepo _departmentsAndRolesRepo;

        public CommonServices(IDepartmentsAndRolesRepo departmentsAndRolesRepo)
        {
            _departmentsAndRolesRepo = departmentsAndRolesRepo;
        }

        public List<string> GetDepartments()
        {
            return _departmentsAndRolesRepo.GetDepartments();
        }

        public List<string> GetRoles(string department)
        {
            return _departmentsAndRolesRepo.GetRoles(department);
        }
    }
}