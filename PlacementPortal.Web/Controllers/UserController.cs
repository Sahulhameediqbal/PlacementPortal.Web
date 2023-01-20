using Microsoft.AspNetCore.Mvc;

namespace PlacementPortal.Web.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
