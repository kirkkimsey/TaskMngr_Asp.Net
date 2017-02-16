using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TasksController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.AssignedUser).Include(t => t.TaskOwner).Include(t => t.TaskPriority).Include(t => t.TaskStatus);
            return View(tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.AssignedToID = new SelectList(db.User, "ID", "fName");
            ViewBag.OwnerID = new SelectList(db.User, "ID", "fName");
            ViewBag.PriorityID = new SelectList(db.Priority, "ID", "Description");
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OwnerID,Title,Description,PriorityID,StatusID,AssignedToID,DateCreated,DueDate,CompleteDate")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(tasks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignedToID = new SelectList(db.User, "ID", "fName", tasks.AssignedToID);
            ViewBag.OwnerID = new SelectList(db.User, "ID", "fName", tasks.OwnerID);
            ViewBag.PriorityID = new SelectList(db.Priority, "ID", "Description", tasks.PriorityID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description", tasks.StatusID);
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignedToID = new SelectList(db.User, "ID", "fName", tasks.AssignedToID);
            ViewBag.OwnerID = new SelectList(db.User, "ID", "fName", tasks.OwnerID);
            ViewBag.PriorityID = new SelectList(db.Priority, "ID", "Description", tasks.PriorityID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description", tasks.StatusID);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OwnerID,Title,Description,PriorityID,StatusID,AssignedToID,DateCreated,DueDate,CompleteDate")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignedToID = new SelectList(db.User, "ID", "fName", tasks.AssignedToID);
            ViewBag.OwnerID = new SelectList(db.User, "ID", "fName", tasks.OwnerID);
            ViewBag.PriorityID = new SelectList(db.Priority, "ID", "Description", tasks.PriorityID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Description", tasks.StatusID);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasks tasks = db.Tasks.Find(id);
            db.Tasks.Remove(tasks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
