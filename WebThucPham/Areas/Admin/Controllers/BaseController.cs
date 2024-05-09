using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThucPham.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessge"] = message;
            if (type == "info")
            {
                TempData["AlertType"] = "toastn--info";
                TempData["ToastHeader"] = "Create";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "toastn--warning";
                TempData["ToastHeader"] = "Edit";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "toastn--error";
                TempData["ToastHeader"] = "Delete";
            }

        }
    }
}