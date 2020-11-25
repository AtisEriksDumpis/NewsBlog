using NewsBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBLibrary;
using static DBLibrary.BuisnessLogic.UserProcesor;

namespace NewsBlog.Controllers
{
    public class HomeController : Controller
    {
        public static User activeUser = new User();
        public ActionResult Index()
        {
            Console.WriteLine(activeUser.Username + activeUser.Pasword+" te ir atbolde");
            var posts = LoadPosts();
            List<Posts> activePosts = new List<Posts>();
            foreach (var post in posts)
            {
                activePosts.Add(new Posts
                {
                    Title = post.Title,
                    Text = post.Text,
                    author = post.author,
                    upWoute = post.upWoute,
                    downWoute = post.downWoute
                });
            }
            ViewBag.show = activeUser.canMakePosts ? true : false;
            ViewData ["actu"] = activeUser.canMakePosts;
            ViewBag.namen = activeUser.Username;
            ViewBag.canmake = activeUser.canMakePosts;
            return View(activePosts);
        }
        public ActionResult LogIn()
        {
            ViewBag.Message = "Login page";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User model)
        {

                var recordsCrieited = UserLogin(model.Username, model.Pasword);
                activeUser = new User { Admin = recordsCrieited.Admin.Equals(1), Username = recordsCrieited.Username, Pasword = recordsCrieited.Pasword, canMakePosts = recordsCrieited.canMakePosts };
                Console.WriteLine(activeUser.Username + activeUser.Pasword+"Tevel nav");
                return RedirectToAction("Index");


            return View();
        
        }

        public ActionResult Delete(int Id)
        {
            DeleteUser(Id);

            return RedirectToAction("AdminView");
        }        
        public ActionResult postMaking(int Id, bool canMakePosts)
        {
            AlowPosting(Id, canMakePosts);

            return RedirectToAction("AdminView");
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Register your new acautn";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var recordsCrieited = RegisterUser(model.Username, model.Pasword, model.saftyAnser);
                //activeUser = new User { Admin = recordsCrieited.Admin.Equals(1), Username = recordsCrieited.Username, Pasword = recordsCrieited.Pasword };
                return RedirectToAction("Index");

            }

            return View();
        }
        public ActionResult MakePost()
        {
            ViewBag.Message = "Register your new acautn";
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakePost(Posts model)
        {
            AddPost(model.Title, model.Text, activeUser.ID);
                //activeUser = new User { Admin = recordsCrieited.Admin.Equals(1), Username = recordsCrieited.Username, Pasword = recordsCrieited.Pasword };
                return RedirectToAction("Index");



            return View();
        }
        public ActionResult Profile()
        {
            ViewBag.Message = "Register your new acautn";
            ViewBag.Username = activeUser.Username;
            ViewBag.ID = activeUser.ID;

            return View();
        }

        [HttpPost]
        public ActionResult ProfilePas(string pasold, string pasnew)
        {
            ///ViewBag.Message = "Register your new acautn";
            //ViewBag.Username = activeUser.Username;
            //ViewBag.ID = activeUser.ID;
            UpdatePasword(activeUser.ID, pasold, pasnew);

            return RedirectToAction("Profile");
        }



        public ActionResult AdminView()
        {
            ViewBag.Message = "AdminScreen";
            var pers = LoadUsers();
            List<User> users = new List<User>();
            foreach(var usr in pers)
            {
                users.Add(new User 
                { 
                Username = usr.Username,
                Pasword = usr.Pasword,
                Admin = usr.Admin,
                ID = usr.ID,
                canMakePosts = usr.canMakePosts,
                });
            }
            return View(users);
        }
        //public ActionResult AdminView()
        //{
        //    ViewBag.Message = "AdminScreen";
        //    var pers = LoadUsers();
        //    List<User> users = new List<User>();
        //    foreach (var usr in pers)
        //    {
        //        users.Add(new User
        //        {
        //            UserName = usr.UserName,
        //            Password = usr.Password,
        //            AdminPrivaleges = usr.AdminPrivaleges
        //        });
        //    }
        //    return View(users);
        //}
    }
}