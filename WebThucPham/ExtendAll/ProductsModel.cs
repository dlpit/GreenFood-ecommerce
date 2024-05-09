using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebThucPham.Models;

namespace WebThucPham.ExtendAll
{
    public class ProductsModel
    {
        dbDoAnEntities db = new dbDoAnEntities();
        public List<Product> ListArr(int id)
        {
            return db.Products.Where(x => x.BestSeller == true).OrderBy(y => y.CreatAt).Take(id).ToList();
        }

        public List<Product> ListSale(int id)
        {
            return db.Products.Where(x => x.BestSeller == true && x.Discount != 0).OrderBy(y => y.CreatAt).Take(id).ToList();
        }

        public List<Product> ListHight(int id)
        {
            return db.Products.Where(x => x.BestSeller == true && x.Instock < 20).OrderBy(y => y.CreatAt).Take(id).ToList();
        }

        public Product ViewDetails(int id)
        { 
            return db.Products.Find(id);
        }

        public List<Product> ViewProducts()
        {
            return db.Products.ToList(); ;
        }
    }
}