﻿using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Infrastructure.Repositories;

namespace PlacementPortal.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            UserRepository = new UserRepository(dbContext);
            CollegeRepository = new CollegeRepository(dbContext);
            CompanyRepository = new CompanyRepository(dbContext);
            CompanyRequestRepository = new CompanyRequestRepository(dbContext);
            PlacementProcessRepository = new PlacementProcessRepository(dbContext);
            StudentInfoRepository = new StudentInfoRepository(dbContext);

            UserTypeRepository = new UserTypeRepository(dbContext);
            StudentStatusRepository = new StudentStatusRepository(dbContext);
            InterviewStatusRepository = new InterviewStatusRepository(dbContext);
            DepartmentRepository = new DepartmentRepository(dbContext);
            CourseRepository = new CourseRepository(dbContext);

        }
        public IUserRepository UserRepository { get; private set; }
        public ICollegeRepository CollegeRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }
        public ICompanyRequestRepository CompanyRequestRepository { get; private set; }
        public IPlacementProcessRepository PlacementProcessRepository { get; private set; }
        public IStudentInfoRepository StudentInfoRepository { get; private set; }

        public IUserTypeRepository UserTypeRepository { get; private set; }
        public IStudentStatusRepository StudentStatusRepository { get; private set; }
        public IInterviewStatusRepository InterviewStatusRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
