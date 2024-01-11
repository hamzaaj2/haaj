using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using Medicine_delivery.Models;

namespace Medicine_delivery.Controllers
{
    [Authorize(Roles = "Doctor, Patient,Pharmacist")]
    public class MedicineOfPatientsController : Controller

    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicineOfPatients
        public ActionResult Index(int caseId)
        {
            var medicineOfPatient = db.MedicineOfPatient.Where(c=>c.CaseId== caseId).Include(m => m.Case).Include(m => m.Medicine);
            return View(medicineOfPatient.ToList());
        }
        public ActionResult MedicinebyPatient(int caseId)
        {
            var medicineOfPatient = db.MedicineOfPatient.Where(c => c.CaseId == caseId).Include(m => m.Case).Include(m => m.Medicine);
            return View(medicineOfPatient.ToList());
        }
        // GET: MedicineOfPatients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineOfPatient medicineOfPatient = db.MedicineOfPatient.Find(id);
            if (medicineOfPatient == null)
            {
                return HttpNotFound();
            }
            return View(medicineOfPatient);
        }

        // GET: MedicineOfPatients/Create
        public ActionResult Create(int caseId)
        {
            ViewBag.MedicineId = new SelectList(db.Medicine, "Id", "BrandName");
            return View();
        }

        // POST: MedicineOfPatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MedicineId,CaseId,Route,Frequency,From,To,SizeOfMedicine")] MedicineOfPatient medicineOfPatient)
        {
            if (ModelState.IsValid)
            {
                medicineOfPatient.Name = db.Medicine.Where(c => c.Id == medicineOfPatient.MedicineId).FirstOrDefault().GenericName;
                db.MedicineOfPatient.Add(medicineOfPatient);
                db.SaveChanges();
                return RedirectToAction("Index",new { caseId = medicineOfPatient.CaseId });
            }
            ViewBag.CaseId = new SelectList(db.Case, "Id", "DoctorId", medicineOfPatient.CaseId);
            ViewBag.MedicineId = new SelectList(db.Medicine, "Id", "BrandName", medicineOfPatient.MedicineId);
            return View(medicineOfPatient);
        }

        // GET: MedicineOfPatients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineOfPatient medicineOfPatient = db.MedicineOfPatient.Find(id);
            if (medicineOfPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseId = new SelectList(db.Case.Where(s=>s.Status==true), "Id", "Name", medicineOfPatient.CaseId);
            ViewBag.MedicineId = new SelectList(db.Medicine, "Id", "BrandName", medicineOfPatient.MedicineId);
            return View(medicineOfPatient);
        }

        // POST: MedicineOfPatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MedicineId,CaseId,Route,Frequency,From,To,SizeOfMedicine")] MedicineOfPatient medicineOfPatient)
        {
            if (ModelState.IsValid)
            {
                var CaseID = medicineOfPatient.CaseId;
                db.Entry(medicineOfPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { caseId = CaseID });
            }
            ViewBag.CaseId = new SelectList(db.Case, "Id", "DoctorId", medicineOfPatient.CaseId);
            ViewBag.MedicineId = new SelectList(db.Medicine, "Id", "BrandName", medicineOfPatient.MedicineId);
            return View(medicineOfPatient);
        }

        // GET: MedicineOfPatients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicineOfPatient medicineOfPatient = db.MedicineOfPatient.Find(id);
            if (medicineOfPatient == null)
            {
                return HttpNotFound();
            }
            return View(medicineOfPatient);
        }

        // POST: MedicineOfPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicineOfPatient medicineOfPatient = db.MedicineOfPatient.Find(id);
            var CaseID = medicineOfPatient.CaseId;
            db.MedicineOfPatient.Remove(medicineOfPatient);
            db.SaveChanges();
            return RedirectToAction("Index",new { caseId = CaseID });
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
