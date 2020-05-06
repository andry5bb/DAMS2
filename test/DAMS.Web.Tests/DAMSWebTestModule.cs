using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DAMS.Web.Startup;
namespace DAMS.Web.Tests
{
    [DependsOn(
        typeof(DAMSWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class DAMSWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DAMSWebTestModule).GetAssembly());
        }
    }
}