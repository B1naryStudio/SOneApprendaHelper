using System.Web.Mvc;

namespace SOneApprendaHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public FileResult GetChromeExtension()
        {
            var path = HttpContext.Server.MapPath("~/App_Data/ApprendaDeveloperPanel.crx");
            return File(path, "application/octet-stream");
        }
    }
}