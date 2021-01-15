using System.Web.Mvc;
using Models;
using Services;

namespace NewsBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SessionHandler sessionHandler = new SessionHandler();
            sessionHandler.makeSesionDataFields();
            return View(HomeHandler.prepData());
        }   
    }
}