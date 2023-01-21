using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface IStudentInfoService
    {
        Task<StudentInfoModel> Get(Guid id);
        Task<List<StudentInfoModel>> GetAll();
        Task Save(StudentInfoModel model);
    }
}
