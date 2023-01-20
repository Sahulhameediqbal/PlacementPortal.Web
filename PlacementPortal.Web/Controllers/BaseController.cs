using Microsoft.AspNetCore.Mvc;

namespace PlacementPortal.Web.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
