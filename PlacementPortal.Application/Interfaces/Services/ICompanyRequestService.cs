using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface ICompanyRequestService
    {
        Task<CompanyRequestModel> Get(Guid id);
        Task<List<CompanyRequestModel>> GetAll();
        Task<List<CompanyRequestModel>> GetAllCompany(Guid companyId);
        Task<List<CompanyRequestModel>> GetAllCollege(Guid collegeId);
        Task<List<CompanyRequestModel>> GetAllCompanyRequest(Guid companyId, Guid collegeId);
        Task<CompanyRequestModel> GetCompanyRequest(Guid companyId, Guid collegeId);
        Task Save(CompanyRequestModel model);
    }
}
