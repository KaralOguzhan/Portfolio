using MvcPortfolio.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolio.Controllers
{
    public class EducationController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblEducation.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation tblEducation)
        {
            db.TblEducation.Add(tblEducation); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = db.TblEducation.Find(id);
            db.TblEducation.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id) 
        {
			var value = db.TblEducation.Find(id);
			return View(value); 
        }
        [HttpPost]
		public ActionResult UpdateEducation(TblEducation tblEducation)
		{
            var value = db.TblEducation.Find(tblEducation.EducationId);
            value.EducationName = tblEducation.EducationName;
            value.EducationSubName = tblEducation.EducationSubName;
            value.EducationDate = tblEducation.EducationDate;
            db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}