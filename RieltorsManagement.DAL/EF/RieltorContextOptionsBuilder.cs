using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RieltorsManagement.DAL
{
    public class RieltorContextOptionsBuilder
    {
        /// <summary>
        /// Получение сведений о конфигурации БД.
        /// </summary>
        /// <returns>Сведения о конфигурации БД.</returns>
        public DbContextOptions GetDbContextOptionsJson()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<RieltorContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return options;
        }
    }
}
