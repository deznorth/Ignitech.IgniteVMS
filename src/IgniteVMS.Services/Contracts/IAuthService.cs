using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IgniteVMS.Entities;

namespace IgniteVMS.Services.Contracts
{
    public interface IAuthService
    {
        public Task<LoginResponse> AuthenticateUser(LoginRequest request);
        public Task<UserResponse> CreateUser(CreateUserRequest request);
    }
}
