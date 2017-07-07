using Monitor.Web.Tool.Filters;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.Controllers
{
    [Monitor]
    [IsAuthority]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}