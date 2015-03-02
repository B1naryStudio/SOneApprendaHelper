using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SOneApprendaHelper.Models;

namespace SOneApprendaHelper.Controllers
{
    public class ApprendaSettingsController : Controller
    {
        private const string APPRENDA_SETTINGS_COOKIES_KEY = "ApprendaSettings";

        [HttpGet]
        public ActionResult Edit()
        {
            ApprendaSettings settings = null;

            if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains(APPRENDA_SETTINGS_COOKIES_KEY))
            {
                var cookies = ControllerContext.HttpContext.Request.Cookies[APPRENDA_SETTINGS_COOKIES_KEY];
                if (cookies != null && !string.IsNullOrEmpty(cookies.Value))
                {
                    settings = JsonConvert.DeserializeObject<ApprendaSettings>(cookies.Value);
                }
            }

            return View(settings);
        }

        [HttpPost]
        public ActionResult Edit(ApprendaSettings settings)
        {
            if (ModelState.IsValid)
            {
                var value = JsonConvert.SerializeObject(settings);
                var cookie = new HttpCookie(APPRENDA_SETTINGS_COOKIES_KEY, value) { Expires = new DateTime(3000, 1, 1) };
                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }

            return View();
        }
    }
}