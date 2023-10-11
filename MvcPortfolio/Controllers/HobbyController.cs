using MvcPortfolio.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolio.Controllers
{
    public class HobbyController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblHobby.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHobby()
        {
            return View();
        }
        [HttpPost]
		public ActionResult AddHobby(TblHobby tblHobby)
        {
            db.TblHobby.Add(tblHobby);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHobby (int id)
        {
            var values = db.TblHobby.Find(id);
            db.TblHobby.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateHobby(int id)
        {
            var values = db.TblHobby.Find(id);
            return View(values);
        }
        [HttpPost]
		public ActionResult UpdateHobby(TblHobby tblHobby)
        {
            var value = db.TblHobby.Find(tblHobby.HobbyId);
            value.Name = tblHobby.Name;
            value.Score = tblHobby.Score;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

	}
}