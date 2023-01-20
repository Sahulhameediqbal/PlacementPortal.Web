using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class AuthenticationController : BaseController
    {
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// Method Called when user login buttion
        /// </summary>
        /// <param name="mdlLogin">User Name</param>
        /// <param name="mdlLogin">Password</param>
        /// <returns>Redirect User</returns>

        [HttpPost]
        public IActionResult LogIn(LogIn mdlLogin)
        {
            return View();
        }
    }
}
