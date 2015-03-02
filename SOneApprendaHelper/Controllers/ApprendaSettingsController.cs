using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SOneApprendaHelper.Models;

namespace SOneApprendaHelper.Controllers
{
    public class ApprendaSettingsController : Controller
    {
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ApprendaSettings settings)
        {
            if (ModelState.IsValid)
            {
                var value = JsonConvert.SerializeObject(settings);
                var cookie = new HttpCookie("ApprendaSettings", value) { Expires = new DateTime(3000, 1, 1) };
                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }

            return View();
        }
    }
}