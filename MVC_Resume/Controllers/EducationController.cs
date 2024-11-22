using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class EducationController : Controller
    {
        EducationRepository education = new EducationRepository();
        // GET: Education
        public ActionResult Index()
        {
            var values = education.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Tbl_Educations tbl)
        {
            education.Add(tbl);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Tbl_Educations tbl = education.Find(x => x.EducationId == id);
            education.Delete(tbl);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tbl_Educations tbl = education.Find(x => x.EducationId == id);
            return View(tbl);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Educations p)
        {
            Tbl_Educations tbl = education.Find(x => x.EducationId == p.EducationId);
            tbl.EducationTitle = p.EducationTitle;
            tbl.EducationSubtitle = p.EducationSubtitle;
            tbl.EducationDescription = p.EducationDescription;
            tbl.EducationAvg = p.EducationAvg;
            tbl.EducationDate = p.EducationDate;
            education.Update(tbl);
            return RedirectToAction("Index");
        }
    }
}