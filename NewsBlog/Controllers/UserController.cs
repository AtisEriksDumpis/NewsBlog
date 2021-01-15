using System.Web.Mvc;
using static DBlibrary.BuisnessLogic.ProcesorUser;
using Models;
using Services;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;

namespace NewsBlog.Controllers
{
    public class UserController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User model)
        {
            PaswordManeger paswordManeger = new PaswordManeger();
            paswordManeger.login(model.Username, model.Pasword);
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                RegiserHandler regiserHandler = new RegiserHandler();
                regiserHandler.registeNewUser(model);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult Forgot(string uName, string sName)
        {
            return View(ForgotenPasword.getUserByParams(uName,sName));
        }

        public ActionResult RegisterNewPasword(int UserID, string newPas)
        {

            ChangePasword(UserID, newPas);
            return RedirectToAction("LogIn");
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "Register your new acautn";
            return View();
        }

        public ActionResult ProfilePas(string pasword, string pasnew)
        {
            return RedirectToAction("Profile");
        }

        public ActionResult ProfileDataChange(string newName, string newSafty)
        {
            SessionHandler sessionHandler = new SessionHandler();
            UpdateProfile((int)Session["ID"], newName, newSafty);
            sessionHandler.setupSessionData((int)Session["ID"]);
            return RedirectToAction("Profile");
        }

        public ActionResult Logaut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}