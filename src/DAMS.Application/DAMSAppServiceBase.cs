using Abp.Application.Services;

namespace DAMS
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class DAMSAppServiceBase : ApplicationService
    {
        protected DAMSAppServiceBase()
        {
            LocalizationSourceName = DAMSConsts.LocalizationSourceName;
        }
    }
}