using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAMS.EntityFrameworkCore
{
    public class DAMSDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public DAMSDbContext(DbContextOptions<DAMSDbContext> options) 
            : base(options)
        {

        }
    }
}
