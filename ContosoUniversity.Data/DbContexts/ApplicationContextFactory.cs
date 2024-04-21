using ContosoUniversity.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ContosoUniversity.Data
{
    // modeled from https://www.benday.com/2017/02/17/ef-core-migrations-without-hard-coding-a-connection-string-using-idbcontextfactory
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("Hosting:Environment")}.json", true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            if (OperatingSystem.IsMacOs())
            {
                builder.UseSqlite("Data Source=ContosoUniversity.sqlite");
            }
            else
            {
                builder.UseSqlServer("Server=contoso.cdbrcyuyp22p.us-east-1.rds.amazonaws.com;Database=ContosoUniversity2017;User=admin;password=AZ4jqjSenJKNCjWX2ngt;MultipleActiveResultSets=true", x => x.MigrationsHistoryTable("Migration", "Contoso"));
            }
            return new ApplicationContext(builder.Options);
        }
    }
}
