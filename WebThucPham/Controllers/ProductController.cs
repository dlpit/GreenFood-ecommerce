using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.ExtendAll;
using WebThucPham.Models;
using PagedList;

namespace WebThucPham.Controllers
{
    public class ProductController : Controller
    {
        dbDoAnEntities db = new dbDoAnEntities();
        // GET: Product
        public ActionResult Index(int page = 1)
        {
            try
            {
                var pageSize = 12;
                var dao = new PageListProduct();
                var model = dao.ListAllPaging(page, pageSize);
                ViewBag.ViewProducts = new ProductsModel().ViewProducts();
                ViewBag.lsHot = new ProductsModel().ListArr(3);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult ListCat(int Id, int page = 1)
        {
            var pageSize = 10;

            var pageIndex = page;

            ViewBag.ViewProducts = new ProductsModel().ViewProducts();
            ViewBag.lsHot = new ProductsModel().ListArr(3);

            var listProduct = db.Products.Where(x => x.Cat_ID == Id).OrderByDescending(x => x.CreatAt).ToPagedList(pageIndex, pageSize);
            return View(listProduct);
        }

        public ActionResult Details(int id)
        {
            var pd = new ProductsModel().ViewDetails(id);
            var lsProduct = db.Products
                .AsNoTracking()
                .Where(x => x.Cat_ID == pd.Cat_ID && x.ID != id && x.Active == true)
                .OrderByDescending(x => x.CreatAt)
                .Take(4).ToList();

            ViewBag.SanPham = lsProduct;
            return View(pd);
        }
    }
}
