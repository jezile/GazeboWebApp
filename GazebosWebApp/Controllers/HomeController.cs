using System.Web.Mvc;

namespace GazebosWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Who we are and what we do.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "See where we are and how to contact us.";

            return View();
        }

        public ActionResult Error404()
        {
            ViewBag.Message = "Your 404 error page.";

            return View();
        }
    }
}