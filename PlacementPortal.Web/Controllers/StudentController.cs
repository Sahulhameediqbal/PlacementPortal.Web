using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class StudentController : Controller
    {
        #region Variable Declartion
        private readonly IStudentInfoService _studentInfoService;
        private readonly IMapper _mapper; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="studentInfoService"></param>
        /// <param name="mapper"></param>
        public StudentController(IStudentInfoService studentInfoService, IMapper mapper) 
        {
            _studentInfoService = studentInfoService;
            _mapper= mapper;
        }

        /// <summary>
        /// Load Student Page with all Student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Student()
        {
            List<StudentInfoModel> lstStudent = new List<StudentInfoModel>();
            lstStudent = _studentInfoService.GetAll().Result;
            return View("Student");
        }

        /// <summary>
        /// Load Studen Page for adding new Student
        /// </summary>
        /// <returns>New Student Page</returns>
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View("AddStudent");
        }


        /// <summary>
        /// Save Student information
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddStudent([FromBody] StudentInfoModel studentData)
        {
            Response reponse = new Response();
            if(studentData == null) 
            {
                return Json(new EmptyResult());
            }

            var studentInfo = _mapper.Map<StudentInfoModel>(studentData);            
            await _studentInfoService.Save(studentInfo);

            if (studentData != null)
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
