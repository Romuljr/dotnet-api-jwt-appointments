using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API02.Infra.Contexts
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            builder.AddJsonFile(path, false);

            var root = builder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
                .GetSection("API02BD").Value;

            var options = new DbContextOptionsBuilder<SqlServerContext>();
            options.UseSqlServer(connectionString);

            return new SqlServerContext(options.Options);

        }
    }
}
