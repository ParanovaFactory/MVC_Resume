using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class InterestController : Controller
    {
        InterestRepository interest = new InterestRepository();
        // GET: Interest
        public ActionResult Index()
        {
            var values = interest.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tbl_Interests tbl = interest.Find(m => m.InterestId == id);
            return View(tbl);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Interests p)
        {
            Tbl_Interests tbl = interest.Find(m => m.InterestId == p.InterestId);
            tbl.InterestDescriptions = p.InterestDescriptions;
            interest.Update(tbl);
            return RedirectToAction("Index");
        }
    }
}