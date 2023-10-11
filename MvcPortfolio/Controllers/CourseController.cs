using MvcPortfolio.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolio.Controllers
{
    public class CourseController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblCourses.ToList();
            return View(values);
        }
        [HttpGet]
		public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
		public ActionResult AddCourse(TblCourses tblCourses) 
        { 
            db.TblCourses.Add(tblCourses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCourse(int id)
        {
            var values = db.TblCourses.Find(id);
            db.TblCourses.Remove(values); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCourse(int id) 
        {
            var values = db.TblCourses.Find(id);
            return View(values);
        }
        [HttpPost]
		public ActionResult UpdateCourse(TblCourses tblCourses)
        {
            var value = db.TblCourses.Find(tblCourses.CourseId);
            value.CourseName = tblCourses.CourseName;
            value.CourseInstructor = tblCourses.CourseInstructor;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}