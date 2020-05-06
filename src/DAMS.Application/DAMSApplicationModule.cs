using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace DAMS
{
    [DependsOn(
        typeof(DAMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DAMSApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DAMSApplicationModule).GetAssembly());
        }
    }
}