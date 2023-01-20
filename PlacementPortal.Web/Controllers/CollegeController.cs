using Microsoft.AspNetCore.Mvc;

namespace PlacementPortal.Web.Controllers
{
    public class CollegeController : BaseController
    {
        public IActionResult College()
        {
            return View();
        }
    }
}
