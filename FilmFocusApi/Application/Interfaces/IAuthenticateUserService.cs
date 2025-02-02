﻿
using FilmFocusApi.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace FilmFocusApi.Application.Interfaces
{
    public interface IAuthenticateUserService
    {
        public Task<AuthenticatedUserDTO> AuthUser(AuthenticateResult authenticateResult);
    }
}
