using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            List<RegisterModel > list = new List<RegisterModel>();  
            //list=_authenticationService.Get
            return View("Register");
        }

        [HttpGet]
        public IActionResult AddRegister()
        {
            List<UserType> types = new List<UserType>();
            //types = _authenticationService.GetType():

            return View("AddRegister");
        }

        [HttpPost]
        public async Task<JsonResult> AddRegister([FromBody] RegisterModel registerData)
        {
            Response reponse = new Response();
            var result = await _authenticationService.Register(registerData);

            if (registerData != null)
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
