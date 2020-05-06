using Abp.AspNetCore.Mvc.Controllers;

namespace DAMS.Web.Controllers
{
    public abstract class DAMSControllerBase: AbpController
    {
        protected DAMSControllerBase()
        {
            LocalizationSourceName = DAMSConsts.LocalizationSourceName;
        }
    }
}