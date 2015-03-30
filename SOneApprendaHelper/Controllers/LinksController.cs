using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SOneApprendaHelper.Models;
using SOneApprendaHelper.Services;

namespace SOneApprendaHelper.Controllers
{
    public class LinksController : Controller
    {
        private readonly ICookiesService _cookiesService;
        private readonly IApprendaLinksGenerator _apprendaLinksGenerator;

        public LinksController(ICookiesService cookiesService, IApprendaLinksGenerator apprendaLinksGenerator)
        {
            _cookiesService = cookiesService;
            _apprendaLinksGenerator = apprendaLinksGenerator;
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(getLinks());
        }

        [HttpGet]
        public ContentResult JsonList()
        {
            var links = getLinks();
            var json = JsonConvert.SerializeObject(links);

            return Content(json, "text/json");
        }

        [HttpGet]
        public ActionResult Navigate(string id)
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                 ControllerContext.HttpContext.Request.Cookies, ApprendaSettings.SETTINGS_KEY);

            if (settings == null)
                return RedirectToAction("List");

            var url = _apprendaLinksGenerator.GenerateApprendaUrl(id, settings);
            if (url == null)
                return RedirectToAction("List");

            return Redirect(url);
        }

        private IEnumerable<ApprendaLink> getLinks()
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                ControllerContext.HttpContext.Request.Cookies, ApprendaSettings.SETTINGS_KEY);

            if (settings == null)
                return null;

            var links = _apprendaLinksGenerator.GenerateApprendaLinks(settings).ToList();
            links.Sort(ApprendaLink.NameComparer);

            return links;
        }
    }
}
