using RequestWorkflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RequestWorkflow.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static List<Event> events = new List<Event>();
        public static int count = 0;

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event evnt = db.Events.Find(id);
            if (evnt == null)
            {
                return HttpNotFound();
            }
            return View(evnt);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event evnt)
        {
            if (evnt.Title == null || evnt.Title.Equals(""))
            {
                return HttpNotFound("Nu s-a gasit");
            }
            db = new ApplicationDbContext();

            count++;
            evnt.Id = count;
            db.Events.Add(evnt);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event evnt = db.Events.Find(id);
            if (evnt == null)
            {
                return HttpNotFound();
            }
            return View("Create", evnt);
        }

        [HttpPost]
        public ActionResult Update(Event user)
        {
            Event exisingUser = db.Events.Find(user.Id);
            exisingUser.Details = user.Details;
            exisingUser.Title = user.Title;
            exisingUser.DateAndTime = user.DateAndTime;
            exisingUser.Location = user.Location;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event evnt = db.Events.Find(id);
            if (evnt == null)
            {
                return HttpNotFound();
            }
            db.Events.Remove(evnt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}