using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Services
{
    public class PlacementProcessService : BaseService, IPlacementProcessService
    {
        public PlacementProcessService(IUnitOfWork unitOfWork, 
                                       IMapper mapper, 
                                       IDateTimeProvider dateTimeProvider, 
                                       ICurrentUserService currentUserService) : base(unitOfWork, mapper, dateTimeProvider, currentUserService)
        {

        }

        public async Task<PlacementProcessModel> Get(Guid id)
        {
            var response = await UnitOfWork.PlacementProcessRepository.Get(id);
            var placementProcess = Mapper.Map<PlacementProcessModel>(response);
            return placementProcess;
        }

        public async Task<List<PlacementProcessModel>> GetAll()
        {
            var response = await UnitOfWork.PlacementProcessRepository.GetAll();
            var placementProcess = Mapper.Map<List<PlacementProcessModel>>(response);
            return placementProcess;
        }

        public async Task Save(PlacementProcessModel model)
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

        private async Task Add(PlacementProcessModel model)
        {
            var placementProcess = Mapper.Map<PlacementProcess>(model);

            placementProcess.Id = Guid.NewGuid();
            placementProcess.IsActive = true;
            placementProcess.CreatedBy = CurrentUserService.UserId;
            placementProcess.CreatedDate = DateTimeProvider.DateTimeOffsetNow;
            placementProcess.ModifiedBy = CurrentUserService.UserId;
            placementProcess.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            await UnitOfWork.PlacementProcessRepository.Add(placementProcess);
        }

        private async Task Update(PlacementProcessModel model)
        {
            var placementProcess = await UnitOfWork.PlacementProcessRepository.Get(model.Id);
            if (placementProcess == null)
            {
                throw new ApplicationException("PlacementProcess not found");
            }

            placementProcess = Mapper.Map(model, placementProcess);

            placementProcess.ModifiedBy = CurrentUserService.UserId;
            placementProcess.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            UnitOfWork.PlacementProcessRepository.Update(placementProcess);
        }
    }
}
