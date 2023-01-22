using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Model.Models;
using System.Security.Claims;

namespace PlacementPortal.Web.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationCustomService _authenticationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public AuthenticationController(IAuthenticationCustomService authenticationService)
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
                await ClaimsIdentity(result);
                response.Status = true;

            }
            else
            {
                response.Status = false;
            }
            return Json(response);
        }

        private async Task ClaimsIdentity(AuthenticationModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new Claim(ClaimTypes.Name, model.Name),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim("ComapanyId", model.ComapanyId.ToString()),
                new Claim("CollegeId", model.CollegeId.ToString()),
                new Claim(ClaimTypes.Role, model.UserType),
            };

            var claimsIdentity = new ClaimsIdentity(
                                claims,
                                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = true
                });
        }
    }
}
