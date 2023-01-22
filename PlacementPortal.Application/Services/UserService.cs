using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, 
                           IMapper mapper,
                           IDateTimeProvider dateTimeProvider, 
                           ICurrentUserService currentUserService) : base(unitOfWork, mapper, dateTimeProvider, currentUserService)
        {

        }

        public async Task<List<UserTypeModel>> GetUserType()
        {
            var result = await UnitOfWork.UserTypeRepository.GetAll();
            var model = Mapper.Map<List<UserTypeModel>>(result);
            return model;
        }

        public async Task<List<StudentStatusModel>> GetStudentStatus()
        {
            var result = await UnitOfWork.StudentStatusRepository.GetAll();
            var model = Mapper.Map<List<StudentStatusModel>>(result);
            return model;
        }

        public async Task<List<InterviewStatusModel>> GetInterviewStatus()
        {
            var result = await UnitOfWork.InterviewStatusRepository.GetAll();
            var model = Mapper.Map<List<InterviewStatusModel>>(result);
            return model;
        }

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            var result = await UnitOfWork.DepartmentRepository.GetAll();
            var model = Mapper.Map<List<DepartmentModel>>(result);
            return model;
        }

        public async Task<List<CourseModel>> GetCourse()
        {
            var result = await UnitOfWork.CourseRepository.GetAll();
            var model = Mapper.Map<List<CourseModel>>(result);
            return model;
        }

    }
}
