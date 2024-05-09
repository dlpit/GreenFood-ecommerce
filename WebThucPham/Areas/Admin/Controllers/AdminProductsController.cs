    using PagedList;
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
    public class AdminProductsController : BaseController
    {
        private dbDoAnEntities db = new dbDoAnEntities();

        public ActionResult Index(int page = 1, int Cat_ID = 0)
        {
            var PageNumber = page;
            var pageSize = 10;

            List<Product> lsProducts = new List<Product>();

            if (Cat_ID != 0)
            {
                lsProducts = db.Products
                    .AsNoTracking()
                    .Where(x => x.Cat_ID == Cat_ID)
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.ID).ToList();
            }
            else
            {
                lsProducts = db.Products
                    .AsNoTracking()
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.ID).ToList();
            }

            PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), PageNumber, pageSize);

            ViewBag.DanhMuc = new SelectList(db.Categories, "ID", "Name", Cat_ID);
            return View(models);
        }

        //-------------------------------------------------------------------------------------

        // GET: Admin/AdminProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/AdminProducts/Create
        public ActionResult Create()
        {
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Cat_ID,Name,Price,Discount,Image,Video,BestSeller,Active,Status,Instock")] Product product)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Thêm sản phẩm thành công", "info");
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", product.Cat_ID);
            return View(product);
        }

        // GET: Admin/AdminProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", product.Cat_ID);
            return View(product);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Cat_ID,Name,Price,Discount,Image,Video,BestSeller,Active,Status,Instock")] Product product)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Sửa sản phẩm thành công", "warning");
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cat_ID = new SelectList(db.Categories, "ID", "Name", product.Cat_ID);
            return View(product);
        }

        // GET: Admin/AdminProducts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Remove(item);
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
