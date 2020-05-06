using DAMS.Configuration;
using DAMS.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAMS.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class DAMSDbContextFactory : IDesignTimeDbContextFactory<DAMSDbContext>
    {
        public DAMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DAMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(DAMSConsts.ConnectionStringName)
            );

            return new DAMSDbContext(builder.Options);
        }
    }
}