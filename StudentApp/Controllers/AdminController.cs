using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Login Page";

            return View();
        }

        private void SignInUser(string username, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult requestStudentPage(string uName, string pwd)
        {
            var url = "";
            try {
                SignInUser(uName, false);
                url = Url.Action("StudentView", "Admin");
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            //var url = Url.Action("StudentView", "Admin");
            return Json(new
            {
                redirectTo = url,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult StudentView()
        {
            ViewBag.Title = "Campus";

            return View();
        }
        [HttpGet]
        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var url = Url.Action("Index", "Admin");
            return Json(new
            {
                redirectTo = url,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
