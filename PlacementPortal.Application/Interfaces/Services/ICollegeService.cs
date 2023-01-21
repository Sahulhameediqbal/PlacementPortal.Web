using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface ICollegeService
    {
        Task<CollegeModel> Get(Guid id);
        Task<List<CollegeModel>> GetAll();
        Task Save(CollegeModel model);
    }
}
