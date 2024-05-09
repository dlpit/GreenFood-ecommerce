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
    public class AdminAccountsController : BaseController
    {
        private dbDoAnEntities db = new dbDoAnEntities();

        // GET: Admin/Accounts
        public ActionResult Index()
        {
            ViewData["QuyenTruyCap"] = new SelectList(db.Roles, "ID", "Describe");

            //var DsAccount = db.Accounts;
            //List<Account> ListRole = DsAccount.ToList();
            //SelectList ListChoose = new SelectList(ListRole, "ID", "Active");
            //ViewBag.List_Roles = ListChoose;

            List<SelectListItem> lsTrangThai = new List<SelectListItem>();
            lsTrangThai.Add(new SelectListItem() { Text = "Active", Value = "1" });
            lsTrangThai.Add(new SelectListItem() { Text = "Block", Value = "2" });
            ViewData["lsTrangThai"] = lsTrangThai;

            var accounts = db.Accounts.Include(a => a.Role);
            return View(accounts.ToList());
        }

        // GET: Admin/Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {
            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Name");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Role_ID,UserName,Password,FullName,Email,PhoneNumber,Address,Active,CreateAt")] Account account)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Thêm tài khoản thành công", "info");
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Name", account.Role_ID);
            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Name", account.Role_ID);
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Role_ID,UserName,Password,FullName,Email,PhoneNumber,Address,Active,CreateAt")] Account account)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Sửa tài khoản thành công", "warning");
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_ID = new SelectList(db.Roles, "ID", "Name", account.Role_ID);
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            SetAlert("Xóa tài khoản thành công", "error");
            db.Accounts.Remove(account);
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
