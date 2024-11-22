using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository contact = new ContactRepository();
        // GET: Contact
        public ActionResult Index()
        {
            var values = contact.GetAll();
            return View(values);
        }

        public ActionResult Delete(int id)
        {
            Tbl_Contact tbl = contact.Find(m => m.ContactId == id);
            contact.Delete(tbl);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Tbl_Contact tbl = contact.Find(m => m.ContactId == id);
            return View(tbl);
        }
    }
}