﻿using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserTypeModel>> GetUserType();
    }
}
