using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> Register(AppUser newUser,string password);
        Task<AppUser> GetUserByEmailOrUsernameAsync(string usernameOrPassword);
    }
}
