using Microsoft.AspNetCore.Mvc;

namespace PlacementPortal.Web.Controllers
{
    public class StudentInfoController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
