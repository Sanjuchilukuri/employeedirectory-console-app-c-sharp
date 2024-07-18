using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface IBaseRepo
    {
        public Data ReadJsonFile();

        public void WriteJsonFile(Data Data);
    }
}