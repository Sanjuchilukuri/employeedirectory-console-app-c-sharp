namespace Application.Interfaces
{
    public interface IRolesServices : ICommonServices
    {

        public void AddRole(string newRole, string department);

        bool IsRoleExists(string newRole);

        public List<string> GetAllRoles();
    }
}
