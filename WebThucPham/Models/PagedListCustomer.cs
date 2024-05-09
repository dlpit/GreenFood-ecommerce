using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebThucPham.Models;
using PagedList;

namespace WebThucPham.Models
{
    public class CatergoryCustomer
    {
        NVL_NQHEntities db = new NVL_NQHEntities();
        public IEnumerable<Customer> ListAllPaging(int page , int pageSize)
        {
            return db.Customers.OrderByDescending(x =>x.ID).ToPagedList(page, pageSize);
        }
    }
}