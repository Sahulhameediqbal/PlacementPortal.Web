using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;

namespace PlacementPortal.Web.Controllers
{
    [Authorize]
    public class CompanyRequestController : BaseController
    {
        #region Variable Declaration
        private readonly ICompanyRequestService _companyRequestService;
        private readonly IMapper _mapper;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyRequestService"></param>
        public CompanyRequestController(ICompanyRequestService companyRequestService, IMapper mapper)
        {
            _companyRequestService = companyRequestService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CompanyRequest()
        {
            //List<CompanyRequestModel> list = new List<CompanyRequestModel>();
            //list = _companyRequestService.GetAll().Result;
            return View("CompanyRequest");
        }

        [HttpGet]
        public JsonResult GetAllCompanyRequest()
        {           
            var lstCompanyRequest = _companyRequestService.GetAll().Result;
            return Json(new { data = lstCompanyRequest });
        }

        [HttpGet]
        public IActionResult AddCompanyRequest()
        {
            return View("AddCompanyRequest");
        }

        [HttpPost]
        public async Task<JsonResult> AddCompanyRequest([FromBody]CompanyRequestModel companyRequestData)
        {
            Response reponse = new Response();
            if (companyRequestData == null)
            {
                return Json(new EmptyResult());
            }

            var companyRequestInfo = _mapper.Map<CompanyRequestModel>(companyRequestData);
            await _companyRequestService.Save(companyRequestInfo);

            if (companyRequestData != null)
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
