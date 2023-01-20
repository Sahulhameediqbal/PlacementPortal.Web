using AutoMapper;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Mappings
{
    public class CollegeProfile : Profile
    {
        public CollegeProfile()
        {
            CreateMap<RegisterModel, College>()
                   .ReverseMap();
        }
    }
}
