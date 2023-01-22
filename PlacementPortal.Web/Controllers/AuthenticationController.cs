using Azure;
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
            AuthenticationModel response = new AuthenticationModel();
            var result = await _authenticationService.Login(login);

            if (result != null)
            {
                response.UserType = result.UserType;
                HttpContext.Session.SetString("UserType", result.UserType);

                if (result.UserType == PlacementPortal.Domain.Enum.UserTypeEnum.Company.ToString())
                {
                    var CompanyId = new Guid("DC43B2F5-0978-49DE-AE7B-977A4425BF73");
                    HttpContext.Session.SetString("ComapanyId", CompanyId.ToString());
                }
                else
                {
                    var CollegeId = new Guid("22925928-880A-4261-BC6B-ABA4BB3FE5FA");
                    HttpContext.Session.SetString("ComapanyId", CollegeId.ToString());
                }
                response.Status = true;

            }
            else
            {
                response.Status = false;
            }
            return Json(response);
        }
    }
}
