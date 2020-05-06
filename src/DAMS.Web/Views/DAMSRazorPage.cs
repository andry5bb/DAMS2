using Abp.AspNetCore.Mvc.Views;

namespace DAMS.Web.Views
{
    public abstract class DAMSRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected DAMSRazorPage()
        {
            LocalizationSourceName = DAMSConsts.LocalizationSourceName;
        }
    }
}
