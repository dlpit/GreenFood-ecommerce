using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebThucPham.Models;

namespace WebThucPham.ModelViews
{
    public class CategoryProduct
    {
        public static List<Product> GetProducts()
        {
            List<Product> lsProducts = new List<Product>();
            dbDoAnEntities db = new dbDoAnEntities("name=dbDoAnEntities");
            lsProducts = db.Set<Product>().ToList<Product>();
            return lsProducts;
        }

        public static List<Product> GetProductsbyCat(int Cat_ID)
        {
            List<Product> lsProductsCat = new List<Product>();
            dbDoAnEntities db = new dbDoAnEntities("name=dbDoAnEntities");
            lsProductsCat = db.Set<Product>().Where(x => x.Cat_ID == Cat_ID).ToList<Product>();
            return lsProductsCat;
        }

        public static List<Category> GetCategory()
        {
            return new dbDoAnEntities("name=dbDoAnEntities").Set<Category>().ToList<Category>();
        }
    }
}