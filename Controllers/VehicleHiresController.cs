using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lindaniDS.Models;

namespace lindaniDS.Controllers
{
    public class VehicleHiresController : Controller
    {
        private LindaniContext db = new LindaniContext();

        // GET: VehicleHires
        public async Task<ActionResult> Index()
        {
            var vehicleHires = db.VehicleHires.Include(v => v.VehicleModel);
            return View(await vehicleHires.ToListAsync());
        }

        // GET: VehicleHires/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleHire vehicleHire = await db.VehicleHires.FindAsync(id);
            if (vehicleHire == null)
            {
                return HttpNotFound();
            }
            return View(vehicleHire);
        }

        // GET: VehicleHires/Create
        public ActionResult Create()
        {
            ViewBag.modelID = new SelectList(db.VehicleModels, "modelID", "vehicleName");
            return View();
        }

        // POST: VehicleHires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "vehicleID,modelID,Email,color,regNo,noPlate,cost,condition,availability")] VehicleHire vehicleHire)
        {
            if (ModelState.IsValid)
            {
                db.VehicleHires.Add(vehicleHire);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.modelID = new SelectList(db.VehicleModels, "modelID", "vehicleName", vehicleHire.modelID);
            return View(vehicleHire);
        }

        // GET: VehicleHires/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleHire vehicleHire = await db.VehicleHires.FindAsync(id);
            if (vehicleHire == null)
            {
                return HttpNotFound();
            }
            ViewBag.modelID = new SelectList(db.VehicleModels, "modelID", "vehicleName", vehicleHire.modelID);
            return View(vehicleHire);
        }

        // POST: VehicleHires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "vehicleID,modelID,Email,color,regNo,noPlate,cost,condition,availability")] VehicleHire vehicleHire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleHire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.modelID = new SelectList(db.VehicleModels, "modelID", "vehicleName", vehicleHire.modelID);
            return View(vehicleHire);
        }

        // GET: VehicleHires/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleHire vehicleHire = await db.VehicleHires.FindAsync(id);
            if (vehicleHire == null)
            {
                return HttpNotFound();
            }
            return View(vehicleHire);
        }

        // POST: VehicleHires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleHire vehicleHire = await db.VehicleHires.FindAsync(id);
            db.VehicleHires.Remove(vehicleHire);
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
