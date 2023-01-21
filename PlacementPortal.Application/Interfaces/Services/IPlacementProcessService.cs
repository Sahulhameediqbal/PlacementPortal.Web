using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface IPlacementProcessService
    {
        Task<PlacementProcessModel> Get(Guid id);
        Task<List<PlacementProcessModel>> GetAll();
        Task Save(PlacementProcessModel model);
    }
}
