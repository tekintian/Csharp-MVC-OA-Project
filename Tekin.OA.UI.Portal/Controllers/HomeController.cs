using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tekin.OA.UI.Portal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           //重定向HTTP请求
           Response.Redirect(Url.Action("Index","UserInfo"));

           return View();
        }

    }
}
