namespace Application.Interfaces
{
    public interface ICommonServices
    {
        public List<string> GetRoles(string department);

        public List<string> GetDepartments();
    }
}