using AutoMapper;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Mappings
{
    public class StudentInfoProfile : Profile
    {
        public StudentInfoProfile()
        {
            CreateMap<StudentInfoModel, StudentInfo>()
                        .ReverseMap();
        }
    }
}
