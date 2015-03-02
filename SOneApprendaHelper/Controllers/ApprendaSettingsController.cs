using System;
using System.Web.Mvc;
using SOneApprendaHelper.Models;
using SOneApprendaHelper.Services;

namespace SOneApprendaHelper.Controllers
{
    public class ApprendaSettingsController : Controller
    {
        private const string APPRENDA_SETTINGS_COOKIES_KEY = "ApprendaSettings";

        private readonly CookiesService _cookiesService = new CookiesService();

        [HttpGet]
        public ActionResult Edit()
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                ControllerContext.HttpContext.Request.Cookies, APPRENDA_SETTINGS_COOKIES_KEY);

            return View(settings);
        }

        [HttpPost]
        public ActionResult Edit(ApprendaSettings settings)
        {
            if (ModelState.IsValid)
            {
                _cookiesService.Set(
                    ControllerContext.HttpContext.Response.Cookies,
                    APPRENDA_SETTINGS_COOKIES_KEY,
                    settings,
                    DateTime.MaxValue);

                ViewBag.AlertMessage = "Apprenda Settings have been successfully saved.";
            }

            return View();
        }
    }
}