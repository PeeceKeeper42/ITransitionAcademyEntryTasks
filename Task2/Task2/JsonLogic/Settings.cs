
using Microsoft.Extensions.Configuration;

namespace Task2.JsonLogic
{
    public static class Settings
    {
        public static IConfiguration Initialize(string fileName)
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile(fileName, optional: false);

            var config = builder.Build();

            return config;
        }
    }
}
