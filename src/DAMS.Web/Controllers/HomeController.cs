using Microsoft.AspNetCore.Mvc;

namespace DAMS.Web.Controllers
{
    public class HomeController : DAMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}