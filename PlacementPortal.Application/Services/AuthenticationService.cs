using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Domain.Enum;
using PlacementPortal.Model.Models;
using PlacementPortal.Shared.Common;

namespace PlacementPortal.Application.Services
{
    public class AuthenticationService : IAuthenticationCustomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected IDateTimeProvider _dateTimeProvider;
        public AuthenticationService(IUnitOfWork unitOfWork,
                                     IMapper mapper,
                                     IDateTimeProvider dateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<AuthenticationModel> Login(LoginModel login)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(x => x.IsActive && x.Email == login.Email);
            if (user == null)
            {
                throw new ApplicationException("Email not found");
            }
            var passwordHash = PasswordHelper.HashUsingPbkdf2(login.Password, Convert.FromBase64String(user.PasswordSalt));
            if (user.Password != passwordHash)
            {
                throw new ApplicationException("Invalid Password");
            }
            var authenticationModel = _mapper.Map<AuthenticationModel>(user);
            if (user.UserTypeId != Guid.Empty)
            {
                var usertype = await _unitOfWork.UserTypeRepository.Get(user.UserTypeId);
                if (usertype != null)
                {
                    authenticationModel.UserType = usertype.Name;
                }
                if (user.UserTypeId == UserTypeEnum.Company.GetEnumGuid())
                {
                    var company = await _unitOfWork.CompanyRepository.FindAsync(x => x.UserId == user.Id);
                    if (company != null)
                    {
                        authenticationModel.ComapanyId = company.Id;
                    }
                }
                else
                {
                    var college = await _unitOfWork.CollegeRepository.FindAsync(x => x.UserId == user.Id);
                    if (college != null)
                    {
                        authenticationModel.CollegeId = college.Id;
                    }
                }
            }


            return authenticationModel;
        }


        public async Task<AuthenticationModel> Register(RegisterModel register)
        {
            var existingUser = await _unitOfWork.UserRepository.FindAsync(x => x.Email == register.Email);
            if (existingUser != null)
            {
                throw new ApplicationException("Email already exists!");
            }

            var salt = PasswordHelper.GetSecureSalt();
            var passwordHash = PasswordHelper.HashUsingPbkdf2(register.Password, salt);
            var user = _mapper.Map<User>(register);

            user.Id = Guid.NewGuid();
            user.Password = passwordHash;
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.IsActive = true;
            user.CreatedBy = user.Id;
            user.CreatedDate = _dateTimeProvider.DateTimeOffsetNow;
            user.ModifiedBy = user.Id;
            user.ModifiedDate = _dateTimeProvider.DateTimeOffsetNow;

            await _unitOfWork.UserRepository.Add(user);

            if (register.UserTypeId == UserTypeEnum.Company.GetEnumGuid())
            {
                var company = _mapper.Map<Company>(register);

                company.Id = Guid.NewGuid();
                company.UserId = user.Id;
                company.IsActive = true;
                company.CreatedBy = user.Id;
                company.CreatedDate = _dateTimeProvider.DateTimeOffsetNow;
                company.ModifiedBy = user.Id;
                company.ModifiedDate = _dateTimeProvider.DateTimeOffsetNow;

                await _unitOfWork.CompanyRepository.Add(company);
            }
            else
            {
                var college = _mapper.Map<College>(register);

                college.Id = Guid.NewGuid();
                college.UserId = user.Id;
                college.IsActive = true;
                college.CreatedBy = user.Id;
                college.CreatedDate = _dateTimeProvider.DateTimeOffsetNow;
                college.ModifiedBy = user.Id;
                college.ModifiedDate = _dateTimeProvider.DateTimeOffsetNow;

                await _unitOfWork.CollegeRepository.Add(college);
            }
            await _unitOfWork.Save();

            var authenticationModel = _mapper.Map<AuthenticationModel>(user);
            return authenticationModel;
        }

    }
}
