using IgniteVMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteVMS.Repositories.Contracts
{
    public interface IAuthRepository
    {
        public Task<User> AuthenticateUser(LoginRequest request);
        public Task<UserResponse> SaveUser(User user);
    }
}
