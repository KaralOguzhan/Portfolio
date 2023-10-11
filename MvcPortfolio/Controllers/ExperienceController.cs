using MvcPortfolio.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        DbCvEntities db=new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblExperience.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience() 
        { 
            return View();
        }
        [HttpPost]
		public ActionResult AddExperience(TblExperience tblExperience)
        {
            db.TblExperience.Add(tblExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            var values = db.TblExperience.Find(id);
            db.TblExperience.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id) 
        { 
            var values =db.TblExperience.Find(id);
            return View(values); 
        }
        [HttpPost]
		public ActionResult UpdateExperience(TblExperience tblExperience)
        {
            var value = db.TblExperience.Find(tblExperience.ExpId);
            value.ExpTitle = tblExperience.ExpTitle;
            value.ExpSubTitle = tblExperience.ExpSubTitle;
            value.ExpDate = tblExperience.ExpDate;
            value.ExpDescription = tblExperience.ExpDescription;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}