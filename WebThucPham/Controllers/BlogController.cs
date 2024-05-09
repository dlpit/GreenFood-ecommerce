using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.ExtendAll;
using WebThucPham.Models;

namespace WebThucPham.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        dbDoAnEntities db = new dbDoAnEntities();
        public ActionResult Index(int page = 1)
        {
            var pageSize = 4;
            var dao = new PageListBlog();
            var model = dao.ListAllPaging(page, pageSize);
            ViewBag.ViewBlogs = new BlogViral().ListBlogAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var pd = new BlogViral().ViewDetails(id);
            var lsBlog = db.Blogs
                .AsNoTracking()
                .Where(x => x.ID == pd.ID && x.Active == true)
                .Take(4).ToList();

            ViewBag.TinTuc = lsBlog;
            return View(pd);
        }
    }
}