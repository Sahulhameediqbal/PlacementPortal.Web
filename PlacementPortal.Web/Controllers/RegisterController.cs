using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class RegisterController : BaseController
    {
        #region Variable Declaration
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public RegisterController(IAuthenticationService authenticationService)
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
            Response reponse = new Response();
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage));
                reponse.Message = message;
            }

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
