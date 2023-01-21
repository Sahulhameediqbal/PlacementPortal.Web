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
        public JsonResult CheckUser(int number1, int number2)
        {
            //LogIn / Registered/Dashboard /Profile
            LoginStatus status = new LoginStatus();
            if (number1 != null)
            {                
                status.Success = true;
                status.TargetURL = "";                
                status.Message = "Login attempt successful!";
                //Session["UserName"] = mdlLogin.Email;
            }
            else
            {
                status.Success = false;
                status.Message = "Invalid UserID or Password!";
                status.TargetURL = "";
            }
            return Json(status);
        }
    }
}
