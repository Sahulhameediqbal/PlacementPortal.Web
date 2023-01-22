using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Services
{
    public class CollegeService : BaseService, ICollegeService
    {        
        public CollegeService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              IDateTimeProvider dateTimeProvider,
                              ICurrentUserService currentUserService) : base(unitOfWork, mapper, dateTimeProvider, currentUserService)
        {
            
        }

        public async Task<CollegeModel> Get(Guid id)
        {
            var response = await UnitOfWork.CollegeRepository.Get(id);
            var college = Mapper.Map<CollegeModel>(response);
            return college;
        }

        public async Task<List<CollegeModel>> GetAll()
        {
            var response = await UnitOfWork.CollegeRepository.GetAll();
            var college = Mapper.Map<List<CollegeModel>>(response);
            return college;
        }

        public async Task Save(CollegeModel model)
        {
            if (model.Id == Guid.Empty)
            {
                await Add(model);
            }
            else
            {
                await Update(model);
            }

            await UnitOfWork.Save();
        }

        private async Task Add(CollegeModel model)
        {
            var college = Mapper.Map<College>(model);

            college.Id = Guid.NewGuid();
            college.IsActive = true;
            college.CreatedBy = CurrentUserService.UserId;
            college.CreatedDate = DateTimeProvider.DateTimeOffsetNow;
            college.ModifiedBy = CurrentUserService.UserId;
            college.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            await UnitOfWork.CollegeRepository.Add(college);
        }

        private async Task Update(CollegeModel model)
        {
            var college = await UnitOfWork.CollegeRepository.Get(model.Id);
            if (college == null)
            {
                throw new ApplicationException("College not found");
            }

            college = Mapper.Map(model, college);
                           
            college.ModifiedBy = CurrentUserService.UserId;
            college.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            UnitOfWork.CollegeRepository.Update(college);
        }
    }
}
