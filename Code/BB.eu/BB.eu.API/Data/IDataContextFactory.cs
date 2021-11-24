using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BB.eu.API.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private readonly IConfiguration configuration;

        public DataContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DataContext CreateDbContext(string[] args = null!)
        {
            var options = new DbContextOptionsBuilder<DataContext>();
            options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            return new DataContext(options.Options);
        }
    }
}