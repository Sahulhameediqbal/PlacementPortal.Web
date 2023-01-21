using AutoMapper;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Mappings
{
    public class LookupProfile : Profile
    {
        public LookupProfile()
        {
            CreateMap<UserTypeModel, UserType>()
                    .ReverseMap();

            CreateMap<StudentStatusModel, StudentStatus>()
                    .ReverseMap();

            CreateMap<InterviewStatusModel, InterviewStatus>()
                    .ReverseMap();

            CreateMap<DepartmentModel, Department>()
                    .ReverseMap();

            CreateMap<CourseModel, Course>()
                    .ReverseMap();
        }
    }
}
