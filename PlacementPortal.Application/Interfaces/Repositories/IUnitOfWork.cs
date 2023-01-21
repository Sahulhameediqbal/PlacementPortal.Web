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

        IUserTypeRepository UserTypeRepository { get; }
        IStudentStatusRepository StudentStatusRepository { get; }
        IInterviewStatusRepository InterviewStatusRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ICourseRepository CourseRepository { get; }

        Task<int> Save();

    }
}
