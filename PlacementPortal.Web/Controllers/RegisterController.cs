using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Web.Controllers
{
    public class RegisterController : BaseController
    {
       
        private readonly IAuthenticationCustomService _authenticationService;
        private readonly IMapper _mapper;
       

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public RegisterController(IAuthenticationCustomService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        /// <summary>
        /// Load Register Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            List<RegisterModel > list = new List<RegisterModel>();  
            //list=_authenticationService.Get
            return View("Register");
        }

        /// <summary>
        /// Open new Register page for adding new User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddRegister()
        {
            List<UserType> types = new List<UserType>();
            //types = _authenticationService.GetType():

            return View("AddRegister");
        }

        //[HttpGet]
        //public JsonResult GetAllUserType()
        //{
        //    UserTypeModel student = new UserTypeModel();
        //    var lstCollege = _collegeService.GetAll().Result;
        //    student.Colleges = lstCollege;
        //    return Json(new { data = student.Colleges });
        //}

        /// <summary>
        /// Save the User Data
        /// </summary>
        /// <param name="registerData"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddRegister([FromBody] RegisterModel registerData)
        {
            AuthenticationModel response = new AuthenticationModel();
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage));
                response.Message = message;
            }

            var result = await _authenticationService.Register(registerData);

            return Json(result);
        }
    }
}
