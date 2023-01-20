namespace PlacementPortal.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ICollegeRepository CollegeRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICompanyRequestRepository CompanyRequestRepository { get; }
        IPlacementProcessRepository PlacementProcessRepository { get; }
        IStudentInfoRepository StudentInfoRepository { get; }
        Task<int> Save();
        
    }
}
