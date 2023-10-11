using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPortfolio.Models.Entity;
namespace MvcPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        public PartialViewResult PartialEducation()
        {
            var values = db.TblEducation.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialCourses()
        {
            var values = db.TblCourses.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience()
        {
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialHobby()
        {
            var values = db.TblHobby.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var v1= db.TblSkill.ToList();
            return PartialView(v1);
        }
        public PartialViewResult PartialProject()
        {
			var values = db.TblTestimonial.ToList();
            return PartialView(values);

		}
        public PartialViewResult PartialAbout() 
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialContact(TblContact tblContact)
        {
            tblContact.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(tblContact);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
	}
}