using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebThucPham.Models;

namespace WebThucPham.ExtendAll
{
    public class BlogViral
    {
        dbDoAnEntities db = new dbDoAnEntities();
        public List<Blog> ListBlog()
        {
            return db.Blogs.Where(x => x.Active == true).OrderBy(y => y.CreateAt).Take(4).ToList();
        }

        public List<Blog> ListBlogAll()
        {
            return db.Blogs.Where(x => x.Active == true).OrderBy(y => y.CreateAt).ToList();
        }

        public Blog ViewDetails(int id)
        {
            return db.Blogs.Find(id);
        }
    }
}