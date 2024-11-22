using MVC_Resume.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Resume.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(Tbl_Admin p)
        {
            Db_ResumeEntities entities = new Db_ResumeEntities();
            var userInfo = entities.Tbl_Admin.FirstOrDefault(x => x.Username == p.Username &&  x.Password == p.Password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Username, false);
                Session["Username"] = userInfo.Username.ToString();
                return RedirectToAction("Index","About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}