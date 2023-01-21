﻿using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    public class CollegeController : BaseController
    {
        [HttpGet]
        public IActionResult College()
        {
            return View("College");
        }

        [HttpGet]
        public IActionResult AddCollege()
        {
            return View("AddCollege");
        }

        [HttpPost]
        public JsonResult AddCollege(CollegeModel data)
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
