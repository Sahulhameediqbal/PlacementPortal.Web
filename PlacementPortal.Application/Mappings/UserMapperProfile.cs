using AutoMapper;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Mappings
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<AuthenticationModel, User>()
                 .ReverseMap();

            CreateMap<RegisterModel, User>()
                .ReverseMap();

            CreateMap<StudentInfoModel, StudentInfo>()
                .ReverseMap();
        }

    }
}
