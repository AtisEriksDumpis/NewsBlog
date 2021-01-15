using System.Web.Mvc;
using static DBlibrary.BuisnessLogic.ProcesorPost;
using static DBlibrary.BuisnessLogic.ProcesorLikes;
using Models;
using Services;
using System;

namespace NewsBlog.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Deletepost(int id)
        {
            DeletePost(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Updatepost(int id, string nTitle, string nText)
        {
            DeletePost(id);
            AddPost(nTitle, nText, (int)Session["ID"]);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MakePost()
        {
            var city = (int)Session["ID"] as Int32?;
            return View();
        }

        public ActionResult MakePostAction(string Title, string Text)
        {
            AddPost(Title, Text, (int)Session["ID"]);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PostView(int PostID)
        {
            return View(PostService.prepPostModal(PostID));
        }

        public ActionResult PostsView()
        {
            return View(PostService.prepPostsModal());
        }

        public ActionResult Serchresults(string serchText)
        {
            return View(SerchSetup.setupSerchModal(serchText));
        }

        public ActionResult LikePost(int PostID)
        {
            short voute = 1;
            RemoveVoute(PostID, (int)Session["ID"]);
            AddVoute(PostID, (int)Session["ID"], voute);
            return RedirectToAction("Index","Home");
        }

        public ActionResult DislikePost(int PostID)
        {
            short voute = -1;
            RemoveVoute(PostID, (int)Session["ID"]);
            AddVoute(PostID, (int)Session["ID"], voute);
            return RedirectToAction("Index", "Home");
        }


    }
}