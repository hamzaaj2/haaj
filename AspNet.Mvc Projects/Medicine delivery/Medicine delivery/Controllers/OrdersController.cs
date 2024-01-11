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
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace Medicine_delivery.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        [Authorize(Roles = "Patient,Pharmacist,Driver,Admin")]
        public ActionResult Index()
        {
            string currentUser = User.Identity.GetUserId();
            var order = db.Order.Include(o => o.Driver).Include(o => o.StatusOfOrder);
            if (User.IsInRole("Patient"))
            {
                List<Order> FilterdOrderd = new List<Order>();
                List<Order> order2 = db.Order.Include(o => o.OrderMedicineOfPatient
                                             .Select(d => d.Case))
                                             .Include(g=>g.Driver)
                                             .Include(o=>o.StatusOfOrder)
                                             .ToList();
                FilterdOrderd = order2.Where(o => o.OrderMedicineOfPatient.FirstOrDefault().Case.Status == true).Where(o => o.OrderMedicineOfPatient.FirstOrDefault().Case.PatientId == currentUser).Where(s => s.StatusOfOrderId > 1).ToList();
                return View(FilterdOrderd);
            }
            else if (User.IsInRole("Driver"))
            {
                order = db.Order.Where(x => x.DriverId == currentUser).Where(s => s.StatusOfOrderId > 1).Include(o => o.Driver).Include(o => o.StatusOfOrder);
                return View(order.ToList());
            }
            return View(order.ToList());
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "Patient,Pharmacist,Driver")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          // Order order = db.Order.Find(id);
            
            Order order = db.Order.Where(c => c.Id == id).Include(o => o.OrderMedicineOfPatient
                                    .Select(d => d.Case).Select(s=>s.Patient)
                                    ).FirstOrDefault();

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        [Authorize(Roles = "Pharmacist")]
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(db.Driver, "Id", "DriverName");
            ViewBag.StatusOfOrderId = new SelectList(db.StatusOfOrder, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pharmacist")]
        public ActionResult Create([Bind(Include = "Id,Name,DriverId,StatusOfOrderId,TimeCompleted")] Order order)
        {
            order.StatusOfOrderId = 1;
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(db.Driver, "Id", "DriverName", order.DriverId);
            ViewBag.StatusOfOrderId = new SelectList(db.StatusOfOrder, "Id", "Name", order.StatusOfOrderId);
            return View(order);
        }
        [Authorize(Roles = "Pharmacist")]
        public ActionResult UnderDelivery(int? id)
        {
            if(true)
            {
                Order order = db.Order.Find(id);
                order.StatusOfOrderId = 2;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Driver")]
        public ActionResult Messing(int? id)
        {
            if (true)
            {
                Order order = db.Order.Find(id);
                order.StatusOfOrderId = 3;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Driver")]
        public ActionResult Delivered(int? id)
        {
            if (true)
            {
                Order order = db.Order.Find(id);
                order.StatusOfOrderId = 4;
                order.TimeCompleted= DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(db.Driver, "Id", "DriverName", order.DriverId);
            ViewBag.StatusOfOrderId = new SelectList(db.StatusOfOrder, "Id", "Name", order.StatusOfOrderId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,DriverId,StatusOfOrderId,TimeCompleted")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(db.Driver, "Id", "DriverName", order.DriverId);
            ViewBag.StatusOfOrderId = new SelectList(db.StatusOfOrder, "Id", "Name", order.StatusOfOrderId);
            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
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
