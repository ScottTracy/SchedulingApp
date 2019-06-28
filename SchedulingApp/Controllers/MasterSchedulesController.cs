using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchedulingApp.Models;

namespace SchedulingApp.Controllers
{
    public class MasterSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MasterSchedules
        public async Task<ActionResult> Index()
        {
            return View(await db.MasterSchedules.ToListAsync());
        }

        // GET: MasterSchedules/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterSchedule masterSchedule = await db.MasterSchedules.FindAsync(id);
            if (masterSchedule == null)
            {
                return HttpNotFound();
            }
            return View(masterSchedule);
        }

        // GET: MasterSchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,StartTime,EndTime,RoleId")] MasterSchedule masterSchedule)
        {
            if (ModelState.IsValid)
            {
                db.MasterSchedules.Add(masterSchedule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(masterSchedule);
        }

        // GET: MasterSchedules/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterSchedule masterSchedule = await db.MasterSchedules.FindAsync(id);
            if (masterSchedule == null)
            {
                return HttpNotFound();
            }
            return View(masterSchedule);
        }

        // POST: MasterSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,StartTime,EndTime,RoleId")] MasterSchedule masterSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterSchedule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(masterSchedule);
        }

        // GET: MasterSchedules/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterSchedule masterSchedule = await db.MasterSchedules.FindAsync(id);
            if (masterSchedule == null)
            {
                return HttpNotFound();
            }
            return View(masterSchedule);
        }

        // POST: MasterSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            MasterSchedule masterSchedule = await db.MasterSchedules.FindAsync(id);
            db.MasterSchedules.Remove(masterSchedule);
            await db.SaveChangesAsync();
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
