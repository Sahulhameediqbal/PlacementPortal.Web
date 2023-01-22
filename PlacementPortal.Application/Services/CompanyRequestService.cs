using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Services
{
    public class CompanyRequestService : BaseService, ICompanyRequestService
    {
        public CompanyRequestService(IUnitOfWork unitOfWork,
                                     IMapper mapper,
                                     IDateTimeProvider dateTimeProvider,
                                     ICurrentUserService currentUserService) : base(unitOfWork, mapper, dateTimeProvider, currentUserService)
        {
        }

        public async Task<CompanyRequestModel> Get(Guid id)
        {
            var response = await UnitOfWork.CompanyRequestRepository.Get(id);
            var companyRequest = Mapper.Map<CompanyRequestModel>(response);
            return companyRequest;
        }

        public async Task<List<CompanyRequestModel>> GetAll()
        {
            var response = await UnitOfWork.CompanyRequestRepository.GetAll();
            var companyRequest = Mapper.Map<List<CompanyRequestModel>>(response);
            return companyRequest;
        }

        public async Task<List<CompanyRequestModel>> GetAllCompany(Guid companyId)
        {
            var response = UnitOfWork.CompanyRequestRepository.Find(x => x.CompanyId == companyId);
            var companyRequest = Mapper.Map<List<CompanyRequestModel>>(response);
            return companyRequest;
        }

        public async Task<List<CompanyRequestModel>> GetAllCollege(Guid collegeId)
        {
            var response = UnitOfWork.CompanyRequestRepository.Find(x => x.CollegeId == collegeId);
            var companyRequest = Mapper.Map<List<CompanyRequestModel>>(response);
            return companyRequest;
        }

        public async Task<List<CompanyRequestModel>> GetAllCompanyRequest(Guid companyId, Guid collegeId)
        {
            var response = UnitOfWork.CompanyRequestRepository.Find(x => x.CompanyId == companyId
                                                                        && x.CollegeId == collegeId);
            var companyRequest = Mapper.Map<List<CompanyRequestModel>>(response);
            return companyRequest;
        }

        public async Task<CompanyRequestModel> GetCompanyRequest(Guid companyId, Guid collegeId)
        {
            var response = await UnitOfWork.CompanyRequestRepository.FindAsync(x => x.CompanyId == companyId
                                                                                    && x.CollegeId == collegeId
                                                                                    && x.CollegeResponse == false);
            var companyRequest = Mapper.Map<CompanyRequestModel>(response);
            return companyRequest;
        }


        public async Task Save(CompanyRequestModel model)
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

        private async Task Add(CompanyRequestModel model)
        {
            var companyRequest = Mapper.Map<CompanyRequest>(model);

            companyRequest.Id = Guid.NewGuid();
            companyRequest.CreatedBy = CurrentUserService.UserId;
            companyRequest.CreatedDate = DateTimeProvider.DateTimeOffsetNow;
            companyRequest.ModifiedBy = CurrentUserService.UserId;
            companyRequest.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            await UnitOfWork.CompanyRequestRepository.Add(companyRequest);
        }

        private async Task Update(CompanyRequestModel model)
        {
            var companyRequest = await UnitOfWork.CompanyRequestRepository.Get(model.Id);
            if (companyRequest == null)
            {
                throw new ApplicationException("CompanyRequest not found");
            }

            companyRequest = Mapper.Map(model, companyRequest);

            companyRequest.ModifiedBy = CurrentUserService.UserId;
            companyRequest.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            UnitOfWork.CompanyRequestRepository.Update(companyRequest);
        }
    }
}
