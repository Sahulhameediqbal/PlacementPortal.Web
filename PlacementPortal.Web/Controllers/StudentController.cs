using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        #region Variable Declartion
        private readonly IStudentInfoService _studentInfoService;
        private readonly IMapper _mapper;
        private readonly ICollegeService _collegeService;
        private readonly IUserService _userService;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="studentInfoService"></param>
        /// <param name="mapper"></param>
        public StudentController(IStudentInfoService studentInfoService, IMapper mapper, ICollegeService collegeService, IUserService userService)
        {
            _studentInfoService = studentInfoService;
            _mapper = mapper;
            _collegeService = collegeService;
            _userService = userService;
        }

        /// <summary>
        /// Load Student Page with all Student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Student()
        {
            List<StudentInfoModel> lstStudent = new List<StudentInfoModel>();
            lstStudent = await _studentInfoService.GetAll();
            return View("Student");
        }

        //[HttpGet]
        //public async Task<JsonResult> GetAllCourse()
        //{
        //    var lstCourse = await _userService.GetCourse();
        //    return Json(new { data = lstCourse });
        //}

        [HttpGet]
        public async Task<JsonResult> GetAllDepartment()
        {
            var lstDepartment = await _userService.GetDepartment();
            return Json(new { data = lstDepartment });
        }

        /// <summary>
        /// Load Studen Page for adding new Student
        /// </summary>
        /// <returns>New Student Page</returns>
        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            StudentInfoModel student = new StudentInfoModel();
            var lstCollege = await _collegeService.GetAll();
            student.Colleges = lstCollege;
            return View("AddStudent", student);
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
            if (studentData == null)
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
