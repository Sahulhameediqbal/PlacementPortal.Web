using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Services
{
    public class StudentInfoService : BaseService, IStudentInfoService
    {
        public StudentInfoService(IUnitOfWork unitOfWork, 
                                  IMapper mapper, 
                                  IDateTimeProvider dateTimeProvider, 
                                  ICurrentUserService currentUserService) : base(unitOfWork, mapper, dateTimeProvider, currentUserService)
        {
        }

        public async Task<StudentInfoModel> Get(Guid id)
        {
            var response = await UnitOfWork.StudentInfoRepository.Get(id);
            var studentInfo = Mapper.Map<StudentInfoModel>(response);
            return studentInfo;
        }

        public async Task<List<StudentInfoModel>> GetAll()
        {
            var response = await UnitOfWork.StudentInfoRepository.GetAll();
            var studentInfo = Mapper.Map<List<StudentInfoModel>>(response);
            return studentInfo;
        }

        public async Task<List<StudentInfoModel>> GetAllCurrent()
        {
            var response = await GetAll(CurrentUserService.CollegeId);
            return response;
        }

        public async Task<List<StudentInfoModel>> GetAll(Guid collegeId)
        {
            var response = UnitOfWork.StudentInfoRepository.Find(x => x.CollegeId == collegeId);
            var studentInfo = Mapper.Map<List<StudentInfoModel>>(response);
            return studentInfo;
        }

        public async Task Save(StudentInfoModel model)
        {
            if (model.Id == Guid.Empty)
            {
                await Add(model);
            }
            else
            {
                await Update(model);
            }
            try
            {
                await UnitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private async Task Add(StudentInfoModel model)
        {
            var studentInfo = Mapper.Map<StudentInfo>(model);

            studentInfo.Id = Guid.NewGuid();
            studentInfo.IsActive = true;
            studentInfo.CreatedBy = CurrentUserService.UserId;
            studentInfo.CreatedDate = DateTimeProvider.DateTimeOffsetNow;
            studentInfo.ModifiedBy = CurrentUserService.UserId;
            studentInfo.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            await UnitOfWork.StudentInfoRepository.Add(studentInfo);
        }

        private async Task Update(StudentInfoModel model)
        {
            var studentInfo = await UnitOfWork.StudentInfoRepository.Get(model.Id);
            if (studentInfo == null)
            {
                throw new ApplicationException("StudentInfo not found");
            }

            studentInfo = Mapper.Map(model, studentInfo);

            studentInfo.ModifiedBy = CurrentUserService.UserId;
            studentInfo.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            UnitOfWork.StudentInfoRepository.Update(studentInfo);
        }
    }
}
