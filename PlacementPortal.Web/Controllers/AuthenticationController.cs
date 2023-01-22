using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public  AuthenticationController(IAuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Load the LogIn Page
        /// </summary>
        /// <returns>LogIn Page</returns>
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
        public async Task<JsonResult> CheckUser([FromBody] LoginModel login)
        {
            var result = await _authenticationService.Login(login);

            LoginStatus status = new LoginStatus();
            if (login != null)
            {
                status.Id = result.Id;
                status.Email = result.Email;
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
