using Application.Interfaces;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class RolesServices : CommonServices, IRolesServices
    {
        private IDepartmentsAndRolesRepo _departmentsAndRolesRepo;

        public RolesServices(IDepartmentsAndRolesRepo departmentsAndRolesRepo) : base(departmentsAndRolesRepo)
        {
            _departmentsAndRolesRepo = departmentsAndRolesRepo;
        }

        public void AddRole(string newRole, string department)
        {
            _departmentsAndRolesRepo.AddRole(newRole, department);
        }


        public bool IsRoleExists(string newRole)
        {
            List<string> allRoles = _departmentsAndRolesRepo.GetAllRoles();
            if (allRoles.Contains(newRole))
            {
                return true;
            }
            return false;
        }

        public List<string> GetAllRoles()
        {
            return _departmentsAndRolesRepo.GetAllRoles();
        }
    }
}