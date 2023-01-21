using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class CollegeController : BaseController
    {
        private readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }

        [HttpGet]
        public IActionResult College()
        {
            List<CollegeModel> lstCollege = new List<CollegeModel>();
            //lstCollege = _collegeService.GetAll();

            return View("College", lstCollege);
        }

        [HttpGet]
        public IActionResult AddCollege()
        {
            return View("AddCollege");
        }

        [HttpPost]
        public JsonResult AddCollege([FromBody]CollegeModel collegeData)
        {            
            Response reponse = new Response();

            if (collegeData != null)
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
