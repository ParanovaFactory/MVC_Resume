using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository about = new AboutRepository();
        // GET: About
        public ActionResult Index()
        {
            var values = about.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tbl_About tbl = about.Find(x => x.AboutId == id);
            return View(tbl);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_About p)
        {
            Tbl_About tbl = about.Find(x => x.AboutId == p.AboutId);
            tbl.AboutName = p.AboutName;
            tbl.AboutSurname = p.AboutSurname;
            tbl.AboutAddress = p.AboutAddress;
            tbl.AboutMail = p.AboutMail;
            tbl.AboutPhone = p.AboutPhone;
            tbl.AboutContext = p.AboutContext;
            tbl.AboutGitHub = p.AboutGitHub;
            tbl.AboutLinkedin = p.AboutLinkedin;
            tbl.AboutImage = p.AboutImage;
            about.Update(tbl);
            return RedirectToAction("Index");
        }
    }
}