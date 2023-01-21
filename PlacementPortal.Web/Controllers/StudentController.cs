using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Student()
        {
            return View("Student");
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View("AddStudent");
        }

        [HttpPost]
        public JsonResult AddStudent(StudentModel data)
        {
            Response reponse = new Response();

            if (data != null)
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
