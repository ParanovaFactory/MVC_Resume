using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class LanguageController : Controller
    {
        LanguageRepository repository = new LanguageRepository();
        // GET: Language
        public ActionResult Index()
        {
            var values = repository.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Tbl_Languages tbl)
        {
            repository.Add(tbl);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Tbl_Languages tbl = repository.Find(m => m.LanguageId == id);
            repository.Delete(tbl);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tbl_Languages tbl = repository.Find(m => m.LanguageId == id);
            return View(tbl);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Languages p)
        {
            Tbl_Languages tbl = repository.Find(m => m.LanguageId == p.LanguageId);
            tbl.LanguageDescription = p.LanguageDescription;
            repository.Update(tbl);
            return RedirectToAction("Index");
        }
    }
}