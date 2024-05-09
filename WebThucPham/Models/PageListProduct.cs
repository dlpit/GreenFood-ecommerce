using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class PageListProduct
    {
        dbDoAnEntities db = new dbDoAnEntities();
        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            return db.Products.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}