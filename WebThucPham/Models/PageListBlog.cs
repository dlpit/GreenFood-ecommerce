using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThucPham.Models
{
    public class PageListBlog
    {
        dbDoAnEntities db = new dbDoAnEntities();
        public IEnumerable<Blog> ListAllPaging(int page, int pageSize)
        {
            return db.Blogs.OrderByDescending(x => x.CreateAt).ToPagedList(page, pageSize);
        }
    }
}