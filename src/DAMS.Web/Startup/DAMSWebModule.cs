using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DAMS.Configuration;
using DAMS.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace DAMS.Web.Startup
{
    [DependsOn(
        typeof(DAMSApplicationModule), 
        typeof(DAMSEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class DAMSWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public DAMSWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(DAMSConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<DAMSNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(DAMSApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DAMSWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DAMSWebModule).Assembly);
        }
    }
}