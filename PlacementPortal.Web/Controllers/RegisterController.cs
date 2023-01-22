using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;
using PlacementPortal.Shared.Common;
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
            AuthenticationModel response = new AuthenticationModel();
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage));
                //reponse.Message = message;
            }

            var result = await _authenticationService.Register(registerData);

            if (registerData != null)
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
                response.Message = "Something went wrong. Please try again later!";
            }
            return Json(response);
        }
    }
}
