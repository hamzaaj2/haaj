using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medicine_delivery.Models;
using Microsoft.AspNet.Identity;

namespace Medicine_delivery.Controllers
{
    
    public class MedicalTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalTests
        [Authorize(Roles = "Doctor, Patient")]
        public ActionResult Index(int caseId)
        {
            string currentUser = User.Identity.GetUserId();
            var medicalTests = db.MedicalTests.Where(c => c.CaseId == caseId).Include(m => m.Case).Include(m => m.MedicalExamination);
            return View(medicalTests.ToList());
        }

        // GET: MedicalTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            if (medicalTest == null)
            {
                return HttpNotFound();
            }
            return View(medicalTest);
        }
        [Authorize(Roles = "Doctor")]
        // GET: MedicalTests/Create
        public ActionResult Create(int caseId)
        {
            ViewBag.MedicalExaminationId = new SelectList(db.MedicalExamination, "Id", "Name");

            return View();
        }

        // POST: MedicalTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Create([Bind(Include = "Id,CaseId,MedicalExaminationId,Note,ImagePath,ImageFile")] MedicalTest medicalTest)

        {
                        
            if (ModelState.IsValid)
            {
                db.MedicalTests.Add(medicalTest);
                db.SaveChanges();
                return RedirectToAction("Index", new { caseId = medicalTest.CaseId });
            }

            ViewBag.CaseId = new SelectList(db.Case, "Id", "DoctorId", medicalTest.CaseId);
            ViewBag.MedicalExaminationId = new SelectList(db.MedicalExamination, "Id", "Name", medicalTest.MedicalExaminationId);
            return View(medicalTest);
        }

        // GET: MedicalTests/Edit/5
        [Authorize(Roles = "Doctor,Patient")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            if (medicalTest == null)
            {
                return HttpNotFound();
            }

            ViewBag.CaseId = new SelectList(db.Case, "Id", "CaseName", medicalTest.CaseId);
            ViewBag.MedicalExaminationId = new SelectList(db.MedicalExamination, "Id", "Name", medicalTest.MedicalExaminationId);
            return View(medicalTest);
        }

        // POST: MedicalTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor,Patient")]
        public ActionResult Edit([Bind(Include = "Id,CaseId,MedicalExaminationId,Note,ImagePath,ImageFile")] MedicalTest medicalTest)
        {
            if (medicalTest.ImagePath == null)
            {
                string fileName = Path.GetFileNameWithoutExtension(medicalTest.ImageFile.FileName);
                string extension = Path.GetExtension(medicalTest.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                medicalTest.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                medicalTest.ImageFile.SaveAs(fileName);
                medicalTest.UploadTime = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                var CaseID = medicalTest.CaseId;
                db.Entry(medicalTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { caseId = CaseID });
            }

            ViewBag.CaseId = new SelectList(db.Case, "Id", "DoctorId", medicalTest.CaseId);
            ViewBag.MedicalExaminationId = new SelectList(db.MedicalExamination, "Id", "Name", medicalTest.MedicalExaminationId);
            return View(medicalTest);
        }
        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult ViewMedicalTest(MedicalTest medicalTest,int id)
        {
                medicalTest = db.MedicalTests.Where(i => i.Id == id).FirstOrDefault();
                return View(medicalTest);
        }

        // GET: MedicalTests/Delete/5
        [Authorize(Roles = "Doctor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            if (medicalTest == null)
            {
                return HttpNotFound();
            }
            return View(medicalTest);
        }

        // POST: MedicalTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalTest medicalTest = db.MedicalTests.Find(id);
            var CaseID = medicalTest.CaseId;
            db.MedicalTests.Remove(medicalTest);
            db.SaveChanges();
            return RedirectToAction("Index", new { caseId = CaseID });
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
