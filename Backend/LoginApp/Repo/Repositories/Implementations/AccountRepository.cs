using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repo.Data;
using Repo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repositories.Implementations
{
    public class AccountRepository:IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<AppUser> entities;
        private readonly UserManager<AppUser> _userManager;
        public AccountRepository(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            entities = _context.Set<AppUser>();
            _userManager = userManager;
        }

        public async Task<AppUser> GetUserByEmailOrUsernameAsync(string usernameOrPassword)
        {
            AppUser appuser = await _userManager.FindByEmailAsync(usernameOrPassword);
            if (appuser is not null)
            {
                return appuser;
            }
            else
            {
                appuser = await _userManager.FindByNameAsync(usernameOrPassword);                
                return appuser;
            }

        }

        public async Task<bool> Register(AppUser newUser, string password)
        {
           var result= await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
            
        }
    }
}
