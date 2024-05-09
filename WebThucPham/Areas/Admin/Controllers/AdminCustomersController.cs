using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebThucPham.Models;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class AdminCustomersController : BaseController
    {
        private dbDoAnEntities db = new dbDoAnEntities();

        // GET: Admin/AdminCustomers
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var cate = new PapeListCustomer();
            var model = cate.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/AdminCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/AdminCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,FullName,BirthDay,Avatar,Email,PhoneNumber,Password,LastLogin,Active")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Thêm tài khoản thành công", "info");
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Admin/AdminCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/AdminCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,FullName,BirthDay,Avatar,Email,PhoneNumber,Password,LastLogin,Active")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Sửa tài khoản thành công", "warning");
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Admin/AdminCustomers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Customers.Find(id);
            if (item != null)
            {
                db.Customers.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
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
