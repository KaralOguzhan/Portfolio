using MvcPortfolio.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial tblTestimonial)
        {
            db.TblTestimonial.Add(tblTestimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ChangeTestimonialStatus(int id)
        {
            var values = db.TblTestimonial.Find(id);
            values.Status=!values.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            return View(values);
        }
        [HttpPost]
		public ActionResult UpdateTestimonial(TblTestimonial tblTestimonial)
        {
            var values = db.TblTestimonial.Find(tblTestimonial.TestimonialId);
            values.FullName = tblTestimonial.FullName;
            values.Title = tblTestimonial.Title;
            values.Comment = tblTestimonial.Comment;
            values.ImageUrl = tblTestimonial.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}