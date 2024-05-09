using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class PagedListProduct
    {
        NVL_NQHEntities db = new NVL_NQHEntities();
        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            return db.Products.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
}