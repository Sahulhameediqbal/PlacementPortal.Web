using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpGet]
        public IActionResult AddRegister()
        {
            return View("AddRegister");
        }

        [HttpPost]
        public JsonResult AddRegister(RegisterModel data)
        {
            Response reponse = new Response();

            if (data != null)
            {
                reponse.Success = true;
                reponse.Message = "Data saved successfully!";
            }
            else
            {
                reponse.Success = false;
                reponse.Message = "Something went wrong. Please try again later!";
            }
            return Json(reponse);
        }
    }
}
