using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SOneApprendaHelper.Models;
using SOneApprendaHelper.Services;

namespace SOneApprendaHelper.Controllers
{
    public class ApprendaLinksController : Controller
    {
        private readonly CookiesService _cookiesService = new CookiesService();

        public ActionResult List()
        {
            return View(getLinks());
        }

        public ContentResult JsonList()
        {
            var links = getLinks();
            var json = JsonConvert.SerializeObject(links);

            return Content(json, "text/json");
        }

        public ActionResult Navigate(string id)
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                 ControllerContext.HttpContext.Request.Cookies, ApprendaSettings.SETTINGS_KEY);

            if (settings == null)
                return RedirectToAction("List");

            var url = ApprendaLinksGenerator.Instance.GenerateApprendaUrl(id, settings);
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

            var links = ApprendaLinksGenerator.Instance.GenerateApprendaLinks(settings).ToList();
            links.Sort(ApprendaLink.NameComparer);

            return links;
        }
    }
}
