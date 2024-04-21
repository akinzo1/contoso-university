using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ContosoUniversity.Data.DbContexts
{
    public class SecureApplicationContextFactory : IDesignTimeDbContextFactory<SecureApplicationContext>
    {
        public SecureApplicationContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("Hosting:Environment")}.json", true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<SecureApplicationContext>();

            if (OperatingSystem.IsMacOs())
            {
                builder.UseSqlite("Data Source=ContosoUniversity.sqlite");
            }
            else
            {
                builder.UseSqlServer("Server=contoso.cdbrcyuyp22p.us-east-1.rds.amazonaws.com;Database=ContosoUniversity2017;User=admin;password=AZ4jqjSenJKNCjWX2ngt;MultipleActiveResultSets=true");

            }
            return new SecureApplicationContext(builder.Options);
        }
    }
}
