﻿using System;
using System.Web.Mvc;
using SOneApprendaHelper.Models;
using SOneApprendaHelper.Services;

namespace SOneApprendaHelper.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ICookiesService _cookiesService;

        public SettingsController(ICookiesService cookiesService)
        {
            _cookiesService = cookiesService;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                ControllerContext.HttpContext.Request.Cookies, ApprendaSettings.SETTINGS_KEY) ?? new ApprendaSettings();

            return View(settings);
        }

        [HttpPost]
        public ActionResult Edit(ApprendaSettings settings)
        {
            if (ModelState.IsValid)
            {
                _cookiesService.Set(
                    ControllerContext.HttpContext.Response.Cookies,
                    ApprendaSettings.SETTINGS_KEY,
                    settings,
                    DateTime.MaxValue);

                ViewBag.AlertMessage = "Apprenda Settings have been saved successfully.";
            }

            return View();
        }
    }
}