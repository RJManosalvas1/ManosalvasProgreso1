using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ManosalvasProgreso1.Data
{
    public class ManosalvasProgreso1ContextFactory : IDesignTimeDbContextFactory<ManosalvasProgreso1Context>
    {
        public ManosalvasProgreso1Context CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ManosalvasProgreso1Context>();
            var connectionString = configuration.GetConnectionString("ManosalvasProgreso1Context");

            optionsBuilder.UseSqlServer(connectionString);

            return new ManosalvasProgreso1Context(optionsBuilder.Options);
        }
    }
}
