using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace DAMS.EntityFrameworkCore
{
    [DependsOn(
        typeof(DAMSCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class DAMSEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DAMSEntityFrameworkCoreModule).GetAssembly());
        }
    }
}