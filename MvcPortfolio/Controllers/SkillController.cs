using MvcPortfolio.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolio.Controllers
{
    public class SkillController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill() 
        { 
            return View();
        }
        [HttpPost]
		public ActionResult AddSkill(TblSkill tblSkill)
        {
            db.TblSkill.Add(tblSkill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var values = db.TblSkill.Find(id);
            db.TblSkill.Remove(values); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values = db.TblSkill.Find(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateSkill(TblSkill tblSkill)
        {
            var values = db.TblSkill.Find(tblSkill.SkillId);
            values.Name = tblSkill.Name;
            values.SkillScore = tblSkill.SkillScore;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


	}
}