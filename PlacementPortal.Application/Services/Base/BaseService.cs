using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;

namespace PlacementPortal.Application.Services.Base
{
    public abstract class BaseService
    {
        protected IUnitOfWork UnitOfWork;
        protected IMapper Mapper;
        protected IDateTimeProvider DateTimeProvider;
        protected ICurrentUserService CurrentUserService;
        public BaseService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IDateTimeProvider dateTimeProvider,
                           ICurrentUserService currentUserService)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            DateTimeProvider = dateTimeProvider;
            CurrentUserService = currentUserService;
        }
    }
}
