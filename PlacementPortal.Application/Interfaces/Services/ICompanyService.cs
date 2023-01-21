using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<CompanyModel> Get(Guid id);
        Task<List<CompanyModel>> GetAll();
        Task Save(CompanyModel model);
    }
}
