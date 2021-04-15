using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekin.OA.BLL;
using Tekin.OA.IBLL;
using Tekin.OA.Model;

namespace Tekin.OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        private IUserInfoService userInfoService = new UserInfoService();
        public ActionResult Index()
        {
            ViewData.Model = userInfoService.GetEntities(u => u.Id>1000);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public void Create(UserInfo user)
        {
            userInfoService.Add(user);
            Response.Redirect(Url.Action("Index", "UserInfo"));
        }
        public ActionResult Edit(int Id)
        {
            ViewData.Model = userInfoService.GetEntities(u => u.Id == Id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public void Edit(UserInfo user,FormCollection collection)
        {
            userInfoService.Update(user);
            Response.Redirect(Url.Action("Index","UserInfo"));

        }

        public ActionResult Details(int Id)
        {
            ViewData.Model = userInfoService.GetEntities(u => u.Id == Id).FirstOrDefault();
            return View();
        }
    }
}
