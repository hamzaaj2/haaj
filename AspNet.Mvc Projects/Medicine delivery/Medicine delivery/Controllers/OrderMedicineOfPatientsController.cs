using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medicine_delivery.Models;

namespace Medicine_delivery.Controllers
{
    public class OrderMedicineOfPatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderMedicineOfPatients
        [Authorize(Roles = "Pharmacist,Patient,Admin")]
        public ActionResult Index(int orderId)
        {
            var orderMedicineOfPatient = db.OrderMedicineOfPatient.Where(o => o.OrderId == orderId).Include(o => o.Case).Include(o => o.MedicineOfPatient).Include(o => o.Order);
            return View(orderMedicineOfPatient.ToList());
        }

        // GET: OrderMedicineOfPatients/Details/5
        [Authorize(Roles = "Pharmacist,Patient")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMedicineOfPatient orderMedicineOfPatient = db.OrderMedicineOfPatient.Find(id);
            if (orderMedicineOfPatient == null)
            {
                return HttpNotFound();
            }
            return View(orderMedicineOfPatient);
        }

        // GET: OrderMedicineOfPatients/Create
        [Authorize(Roles = "Pharmacist")]
        public ActionResult Create(int orderId)
        {
            List<Case> CaseList = db.Case.Where(s => s.Status == true).ToList();
            ViewBag.CaseList = new SelectList(CaseList, "Id", "CaseName");
            //ViewBag.CaseId = new SelectList(db.Case.Where(s=>s.Status==true), "Id", "CaseName");
            //ViewBag.MedicineOfPatientId = new SelectList(db.MedicineOfPatient.OrderByDescending(m =>m.From), "Id", "MedicineName");
            ViewBag.OrderId = new SelectList(db.Order, "Id", "Name");
            return View();
        }

        // POST: OrderMedicineOfPatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pharmacist")]
        public ActionResult Create( OrderMedicineOfPatient orderMedicineOfPatient)
        {
            
            if (true)
            {
                db.OrderMedicineOfPatient.Add(orderMedicineOfPatient);
                db.SaveChanges();
                return RedirectToAction("Index", new { orderId = orderMedicineOfPatient.OrderId });
            }
            //List<Case> CaseList = db.Case.Where(s => s.Status == true).ToList();
            //ViewBag.CaseList = new SelectList(CaseList, "Id", "CaseName", orderMedicineOfPatient.CaseId);
            //ViewBag.CaseId = new SelectList(db.Case.Where(s => s.Status == true), "Id", "CaseName", orderMedicineOfPatient.CaseId);
            //List<MedicineOfPatient> MedicineOfPatientList = db.MedicineOfPatient.Where(c => c.CaseId == CaseId).ToList();
            //ViewBag.MedicineOfPatientId = new SelectList(db.MedicineOfPatient, "Id", "MedicineName", orderMedicineOfPatient.MedicineOfPatientId);
            //ViewBag.OrderId = new SelectList(db.Order, "Id", "Name", orderMedicineOfPatient.OrderId);
            //return View(orderMedicineOfPatient);
        }
        public JsonResult GetMedicineList(int CaseId)
        {
            db.Configuration.ProxyCreationEnabled= false;
            List<MedicineOfPatient> MedicineOfPatientList=db.MedicineOfPatient.Where(c=>c.CaseId== CaseId).ToList();
            return Json(MedicineOfPatientList,JsonRequestBehavior.AllowGet);
        }

        // GET: OrderMedicineOfPatients/Edit/5
        [Authorize(Roles = "Pharmacist")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMedicineOfPatient orderMedicineOfPatient = db.OrderMedicineOfPatient.Find(id);
            if (orderMedicineOfPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseId = new SelectList(db.Case.Where(s => s.Status == true), "Id", "CaseName", orderMedicineOfPatient.CaseId);
            ViewBag.MedicineOfPatientId = new SelectList(db.MedicineOfPatient, "Id", "MedicineName", orderMedicineOfPatient.MedicineOfPatientId);
            ViewBag.OrderId = new SelectList(db.Order, "Id", "Name", orderMedicineOfPatient.OrderId);
            return View(orderMedicineOfPatient);
        }

        // POST: OrderMedicineOfPatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pharmacist")]
        public ActionResult Edit([Bind(Include = "Id,Name,CaseId,OrderId,MedicineOfPatientId")] OrderMedicineOfPatient orderMedicineOfPatient)
        {
            if (ModelState.IsValid)
            {
                var OrderID = orderMedicineOfPatient.OrderId;
                db.Entry(orderMedicineOfPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { orderId = OrderID });
            }
            ViewBag.CaseId = new SelectList(db.Case.Where(s => s.Status == true), "Id", "CaseName", orderMedicineOfPatient.CaseId);
            ViewBag.MedicineOfPatientId = new SelectList(db.MedicineOfPatient, "Id", "MedicineName", orderMedicineOfPatient.MedicineOfPatientId);
            ViewBag.OrderId = new SelectList(db.Order, "Id", "Name", orderMedicineOfPatient.OrderId);
            return View(orderMedicineOfPatient);
        }

        // GET: OrderMedicineOfPatients/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMedicineOfPatient orderMedicineOfPatient = db.OrderMedicineOfPatient.Find(id);
            if (orderMedicineOfPatient == null)
            {
                return HttpNotFound();
            }
            return View(orderMedicineOfPatient);
        }

        // POST: OrderMedicineOfPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderMedicineOfPatient orderMedicineOfPatient = db.OrderMedicineOfPatient.Find(id);
            var OrderID = orderMedicineOfPatient.OrderId;
            db.OrderMedicineOfPatient.Remove(orderMedicineOfPatient);
            db.SaveChanges();
            return RedirectToAction("Index", new { orderId = OrderID });
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
