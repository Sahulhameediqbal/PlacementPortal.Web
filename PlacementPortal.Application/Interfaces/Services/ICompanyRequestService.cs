using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface ICompanyRequestService
    {
        Task<CompanyRequestModel> Get(Guid id);
        Task<List<CompanyRequestModel>> GetAll();
        Task Save(CompanyRequestModel model);
    }
}
