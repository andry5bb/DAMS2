using Abp.Modules;
using Abp.Reflection.Extensions;
using DAMS.Localization;

namespace DAMS
{
    public class DAMSCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            DAMSLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DAMSCoreModule).GetAssembly());
        }
    }
}