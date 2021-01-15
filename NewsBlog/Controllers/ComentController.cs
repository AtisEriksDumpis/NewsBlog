using Models;
using System.Web.Mvc;
using static DBlibrary.BuisnessLogic.ProcesorComents;

namespace NewsBlog.Controllers
{
    public class ComentController : Controller
    {
        public ActionResult AddComment(int PostID, string comment)
        {
            AddComments(comment, PostID, (int)Session["ID"]);
            return RedirectToAction("Index","Home");
        }


        public ActionResult Deletecomment(int id)
        {
            DeleteComment(id);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Report(int Id, string mesage)
        {
            ReportComment(Id, mesage);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Hide(int Id)
        {
            HideComment(Id);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Restore(int Id)
        {
            RestoreComment(Id);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Updatecomment(int id, string nText, int curId)
        {
            DeleteComment(curId);
            AddComments(nText, id, (int)Session["ID"]);
            return RedirectToAction("Index", "Home");
        }


    }
}