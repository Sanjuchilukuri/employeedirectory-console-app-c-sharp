namespace Infrastructure.Interfaces
{
    public interface IDepartmentsAndRolesRepo : IBaseRepo
    {
        public void AddRole(string newRole, string department);

        public List<string> GetDepartments();

        public List<string> GetAllRoles();

        public List<string> GetRoles(string department);
    }
}