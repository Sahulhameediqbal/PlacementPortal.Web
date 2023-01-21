using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              IDateTimeProvider dateTimeProvider) : base(unitOfWork, mapper, dateTimeProvider)
        {
        }

        public async Task<CompanyModel> Get(Guid id)
        {
            var response = await UnitOfWork.CompanyRepository.Get(id);
            var company = Mapper.Map<CompanyModel>(response);
            return company;
        }

        public async Task<List<CompanyModel>> GetAll()
        {
            var response = await UnitOfWork.CompanyRepository.GetAll();
            var company = Mapper.Map<List<CompanyModel>>(response);
            return company;
        }

        public async Task Save(CompanyModel model)
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

        private async Task Add(CompanyModel model)
        {
            var company = Mapper.Map<Company>(model);

            company.Id = Guid.NewGuid();
            company.IsActive = true;
            company.CreatedBy = company.Id;
            company.CreatedDate = DateTimeProvider.DateTimeOffsetNow;
            company.ModifiedBy = company.Id;
            company.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            await UnitOfWork.CompanyRepository.Add(company);
        }

        private async Task Update(CompanyModel model)
        {
            var company = await UnitOfWork.CompanyRepository.Get(model.Id);
            if (company == null)
            {
                throw new ApplicationException("Company not found");
            }

            company = Mapper.Map(model, company);

            company.ModifiedBy = company.Id;
            company.ModifiedDate = DateTimeProvider.DateTimeOffsetNow;

            UnitOfWork.CompanyRepository.Update(company);
        }

    }
}
