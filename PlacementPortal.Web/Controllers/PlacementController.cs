using Microsoft.AspNetCore.Mvc;

namespace PlacementPortal.Web.Controllers
{
    public class PlacementController : Controller
    {
        public IActionResult Placement()
        {
            return View("Placement");
        }

        [HttpGet]
        public IActionResult AddPlacement()
        {
            return View("AddPlacement");
        }
    }
}
