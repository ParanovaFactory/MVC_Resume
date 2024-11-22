using Microsoft.Ajax.Utilities;
using MVC_Resume.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    [AllowAnonymous]
    public class PublicController : Controller
    {
        Db_ResumeEntities entities = new Db_ResumeEntities();
        // GET: Public
        public ActionResult Index()
        {
            var values = entities.Tbl_About.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var values = entities.Tbl_Experiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult Education()
        {
            var values = entities.Tbl_Educations.ToList();
            return PartialView(values);
        }

        public PartialViewResult Skill()
        {
            var values = entities.Tbl_Skills.ToList();
            return PartialView(values);
        }

        public PartialViewResult Certificate()
        {
            var values = entities.Tbl_Certificates.ToList();
            return PartialView(values);
        }

        public PartialViewResult Language()
        {
            var values = entities.Tbl_Languages.ToList();
            return PartialView(values);
        }

        public PartialViewResult Interest()
        {
            var values = entities.Tbl_Interests.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Tbl_Contact tbl)
        {
            tbl.ContactDate = DateTime.Now;
            entities.Tbl_Contact.Add(tbl);
            entities.SaveChanges();
            return PartialView();
        }
    }
}