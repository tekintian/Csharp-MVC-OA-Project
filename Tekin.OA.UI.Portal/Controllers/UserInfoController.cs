using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekin.OA.BLL;
using Tekin.OA.IBLL;

namespace Tekin.OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        private IUserInfoService userInfoService = new UserInfoService();
        public ActionResult Index()
        {
            return View();
        }

    }
}
