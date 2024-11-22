using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class SkillController : Controller
    {
        SkillRepository skill = new SkillRepository();
        // GET: Skill
        public ActionResult Index()
        {
            var values = skill.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Tbl_Skills tbl)
        {
            skill.Add(tbl);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Tbl_Skills tbl = skill.Find(x => x.SkillId == id);
            skill.Delete(tbl);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tbl_Skills tbl = skill.Find(x => x.SkillId == id);
            return View(tbl);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Skills p)
        {
            Tbl_Skills tbl = skill.Find(x => x.SkillId == p.SkillId);
            tbl.SkillTitle = p.SkillTitle;
            tbl.SkillName = p.SkillName;
            skill.Update(tbl);
            return RedirectToAction("Index");
        }
    }
}