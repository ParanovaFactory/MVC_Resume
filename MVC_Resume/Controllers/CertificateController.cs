using MVC_Resume.Models.Entity;
using MVC_Resume.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Resume.Controllers
{
    public class CertificateController : Controller
    {
        CertificateRepository certificate = new CertificateRepository();
        // GET: Certificate
        public ActionResult Index()
        {
            var values = certificate.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Tbl_Certificates tbl)
        {
            certificate.Add(tbl);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Tbl_Certificates tbl = certificate.Find(m => m.CertificateId == id);
            certificate.Delete(tbl);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tbl_Certificates tbl = certificate.Find(m => m.CertificateId == id);
            return View(tbl);
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Certificates p)
        {
            Tbl_Certificates tbl = certificate.Find(m => m.CertificateId == p.CertificateId);
            tbl.CertificateTitle = p.CertificateTitle;
            tbl.CertificateOrganization = p.CertificateOrganization;
            tbl.CertificateTime = p.CertificateTime;
            tbl.CertificateDate = p.CertificateDate;
            tbl.CertificateUrl = p.CertificateUrl;
            certificate.Update(tbl);
            return RedirectToAction("Index");
        }
    }
}