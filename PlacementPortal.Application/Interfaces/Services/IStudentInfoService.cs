using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface IStudentInfoService
    {
        Task<StudentInfoModel> Get(Guid id);
        Task<List<StudentInfoModel>> GetAll();
        Task<List<StudentInfoModel>> GetAllCurrent();
        Task<List<StudentInfoModel>> GetAll(Guid collegeId);
        Task Save(StudentInfoModel model);
    }
}
