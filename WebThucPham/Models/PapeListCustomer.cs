using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class PapeListCustomer
    {
        dbDoAnEntities db = new dbDoAnEntities();
        public IEnumerable<Customer> ListAllPaging(int page, int pageSize)
        {
            return db.Customers.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}