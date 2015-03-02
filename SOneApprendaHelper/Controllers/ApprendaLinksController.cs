﻿using System.Web.Mvc;
using SOneApprendaHelper.Models;
using SOneApprendaHelper.Services;

namespace SOneApprendaHelper.Controllers
{
    public class ApprendaLinksController : Controller
    {
        private const string APPRENDA_SETTINGS_COOKIES_KEY = "ApprendaSettings";

        private readonly CookiesService _cookiesService = new CookiesService();

        public ActionResult List()
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                ControllerContext.HttpContext.Request.Cookies, APPRENDA_SETTINGS_COOKIES_KEY);

            if (settings == null)
                return View();

            var links = ApprendaLinksGenerator.Instance.GenerateAllLinks(settings);
            return View(links);
        }

        public ActionResult Navigate(string id)
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                 ControllerContext.HttpContext.Request.Cookies, APPRENDA_SETTINGS_COOKIES_KEY);

            if (settings == null)
                return RedirectToAction("List");

            var url = ApprendaLinksGenerator.Instance.GenerateUrl(id, settings);
            if (url == null)
                return RedirectToAction("List");

            return Redirect(url);
        }
    }
}
