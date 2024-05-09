using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThucPham.ExtendAll;
using WebThucPham.Models;

namespace WebThucPham.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialProCate()
        {
            List<Product> lsProduct = ProCatHome.getProductInCat(8);
            return PartialView("_PartialProCate");
        }

        public ActionResult PartialBannerSale()
        {
            ViewBag.BannerSale = new ProductsModel().ListSale(3);
            return PartialView("_PartialBannerSale");
        }

        public ActionResult PartialArrival()
        {
            ViewBag.ArrivalProducts = new ProductsModel().ListArr(5);
            return PartialView("_PartialArrival");
        }

        public ActionResult HighlightProducts()
        {
            ViewBag.HighlightProducts = new ProductsModel().ListHight(6);
            return PartialView("_PartialHighlightProducts");
        }

        public ActionResult BlogViral()
        {
            ViewBag.BlogViral = new BlogViral().ListBlog();
            return PartialView("_PartialBlogViral");
        }
    }
}