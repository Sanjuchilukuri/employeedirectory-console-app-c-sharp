using System.Text.Json;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repos
{
    public class BaseRepo : IBaseRepo
    {
        private readonly string path;

        public BaseRepo()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            path = configuration["EnvironmentVariables:path"]!;
        }

        public Data ReadJsonFile()
        {
            string jsonText = File.ReadAllText(path)!;
            return JsonSerializer.Deserialize<Data>(jsonText)!;
        }

        public void WriteJsonFile(Data Data)
        {
            string updatedJsonFile = JsonSerializer.Serialize(Data);
            File.WriteAllText(path, updatedJsonFile);
        }
    }
}