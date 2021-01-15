using System.Web.Mvc;
using static DBlibrary.BuisnessLogic.ProcesorUser;
using static DBlibrary.BuisnessLogic.ProcesorComents;
using Models;
using Models.ViewSpecificModels;

namespace NewsBlog.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminView()
        {
            AdminModel adminModel = new AdminModel()
            {
                Users = LoadUsers(),
                reportedComments = LoadReportd()
            };
            return View(adminModel);
        }
        public ActionResult postMaking(int Id, bool canMakePosts)
        {
            AlowPosting(Id, canMakePosts);

            return RedirectToAction("AdminView");
        }
        public ActionResult comentMaking(int Id, bool canMakeComents)
        {
            AlowComenting(Id, canMakeComents);

            return RedirectToAction("AdminView");
        }
        public ActionResult DeleteUser(int Id)
        {
            DelUser(Id);

            return RedirectToAction("AdminView");
        }
    }
}