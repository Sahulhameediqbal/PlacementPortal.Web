using AutoMapper;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Mappings
{
    public class CompanyRequestProfile : Profile
    {
        public CompanyRequestProfile()
        {
            CreateMap<CompanyRequestModel, CompanyRequest>()
                       .ReverseMap();
        }
    }
}
