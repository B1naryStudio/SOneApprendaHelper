using System.Web.Mvc;
using SOneApprendaHelper.Models;
using SOneApprendaHelper.Services;

namespace SOneApprendaHelper.Controllers
{
    public class GuidesController : Controller
    {
        private readonly ICookiesService _cookiesService;

        public GuidesController(ICookiesService cookiesService)
        {
            _cookiesService = cookiesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var settings = _cookiesService.Get<ApprendaSettings>(
                ControllerContext.HttpContext.Request.Cookies, ApprendaSettings.SETTINGS_KEY);

            return View(settings);
        }
    }
}