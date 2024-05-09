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
    public class AdminBlogsController : BaseController
    {
        private dbDoAnEntities db = new dbDoAnEntities();

        // GET: Admin/AdminBlogs
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new PageListBlog();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/AdminBlogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/AdminBlogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminBlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Title,Content,CreateAt,Image,active")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Thêm tin tức thành công", "info");
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Admin/AdminBlogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/AdminBlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,CreateAt,Image,active")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Sửa tin tức thành công", "warning");
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Admin/AdminBlogs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Blogs.Find(id);
            if (item != null)
            {
                db.Blogs.Remove(item);
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
