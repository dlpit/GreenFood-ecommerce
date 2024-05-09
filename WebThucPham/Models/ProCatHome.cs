using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class ProCatHome
    {
        public static List<Product> getProducts()
        {
            List<Product> ls = new List<Product>();
            dbDoAnEntities db = new dbDoAnEntities("name=dbDoAnEntities");
            ls = db.Set<Product>().ToList<Product>();
            return ls;
        }

        public static List<Product> getProductInCat(int CatID)
        {
            List<Product> ls = new List<Product>();
            dbDoAnEntities db = new dbDoAnEntities("name=dbDoAnEntities");
            ls = db.Set<Product>().Where(x => x.Cat_ID == CatID).ToList<Product>();
            return ls;
        }

        public static List<Category> getCategory()
        {
            return new dbDoAnEntities("name=BanHangOnlineEntities").Set<Category>().ToList<Category>();
        }
    }
}