using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class ExperienceController : Controller
    {
        ExperineceRepository experineceRepository = new ExperineceRepository();
        // GET: Experience
        public ActionResult Index()
        {
            var value = experineceRepository.GetAll();
            return View(value);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Tbl_Experiences tbl)
        {
            experineceRepository.Add(tbl);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Tbl_Experiences tbl = experineceRepository.Find(x => x.ExperienceId == id);
            experineceRepository.Delete(tbl);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tbl_Experiences tbl = experineceRepository.Find(x => x.ExperienceId == id);
            return View(tbl);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Experiences Exp)
        {
            Tbl_Experiences tbl = experineceRepository.Find(x => x.ExperienceId == Exp.ExperienceId);
            tbl.ExperienceTitle = Exp.ExperienceTitle;
            tbl.ExperienceSubtitle = Exp.ExperienceSubtitle;
            tbl.ExperienceDate = Exp.ExperienceDate;
            tbl.ExperienceDescription = Exp.ExperienceDescription;
            experineceRepository.Update(tbl);
            return RedirectToAction("Index");
        }
    }
}