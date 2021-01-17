using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Warren.Banking.Infra.Context
{
    public class DesignBankingContext : IDesignTimeDbContextFactory<BankingContext>
    {
        private readonly IConfiguration _configuration;

        public DesignBankingContext()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            ;
        }

        public BankingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankingContext>();
            var connectionString = _configuration.GetConnectionString("Default");

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new BankingContext(optionsBuilder.Options);
        }
    }
}