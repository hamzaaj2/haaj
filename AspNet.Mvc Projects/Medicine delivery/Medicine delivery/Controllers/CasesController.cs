using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Medicine_delivery.Models;
using Microsoft.AspNet.Identity;

namespace Medicine_delivery.Controllers
{
    public class CasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cases
        [Authorize(Roles = "Doctor,Patient,Admin,Pharmacist")]
        public ActionResult Index()
        {
            string currentUser = User.Identity.GetUserId();
            var cases = db.Case.Where(s => s.Status == true).Include(m => m.Patient).Include(d => d.Doctor);
            if (User.IsInRole("Doctor"))
            {
                cases = db.Case.Where(s => s.Status == true).Where(x => x.DoctorId == currentUser).Include(m => m.Patient).Include(d => d.Doctor);
            }
            else if (User.IsInRole("Patient"))
            {
                cases = db.Case.Where(s => s.Status == true).Where(x => x.PatientId == currentUser).Include(m => m.Patient).Include(d => d.Doctor);
            }
            else if (User.IsInRole("Admin"))
            {
                cases = db.Case.Include(m => m.Patient).Include(d => d.Doctor);
            }
            return View(cases.ToList());
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult CasesByPatient(string patientId )
        {
            var cases = db.Case.Where(s => s.Status == true).Where(p => p.PatientId == patientId).Include(m => m.Patient).Include(d => d.Doctor);
            return View(cases.ToList());
        }
        
        // GET: Cases/Details/5
        [Authorize(Roles = "Doctor,Patient")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Case.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        [Authorize(Roles = "Doctor")]
        public ActionResult Create()
        {
            //string currentUser = User.Identity.GetUserId();
            //ViewBag.DoctorId = new SelectList(db.Doctor.Where(x => x.Id == currentUser), "Id", "DoctorName");
            ViewBag.MedicalExaminationId = new SelectList(db.MedicalExamination, "Id", "Name");
            ViewBag.PatientId = new SelectList(db.Patient, "Id", "PatientInfo");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Create([Bind(Include = "Id,DoctorId,PatientId,Specialty,Status,Diseases,Note")] Case @case)
        {
            @case.DoctorId=User.Identity.GetUserId();
            @case.Status = true;
            if (true)
            {
                db.Case.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DoctorId = new SelectList(db.Doctor, "Id", "DoctorName", @case.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patient, "Id", "PatientInfo", @case.PatientId);
            return View(@case);
        }

        // GET: Cases/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Case.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctor, "Id", "DoctorName", @case.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patient, "Id", "PatientInfo", @case.PatientId);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,DoctorId,PatientId,Specialty,Status,Diseases,Note")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctor, "Id", "DoctorName" + "LastName", @case.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patient, "Id", "PatientInfo", @case.PatientId);
            return View(@case);
        }

        // GET: Cases/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Case.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Case.Find(id);
            db.Case.Remove(@case);
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
