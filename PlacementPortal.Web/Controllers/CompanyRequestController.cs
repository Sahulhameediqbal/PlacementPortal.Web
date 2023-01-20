using Microsoft.AspNetCore.Mvc;

namespace PlacementPortal.Web.Controllers
{
    public class CompanyRequestController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
