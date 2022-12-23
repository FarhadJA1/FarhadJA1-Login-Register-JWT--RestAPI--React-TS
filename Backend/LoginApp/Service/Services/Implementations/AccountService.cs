using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Repo.Repositories.Interfaces;
using Service.DTOs.AccountDTOs;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;        
        private readonly ITokenService _tokenService;
        private readonly IAccountRepository _accountRepository;

        public AccountService(UserManager<AppUser> userManager,                                
                                 ITokenService tokenService,                                 
                                 IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;            
            _accountRepository = accountRepository;
        }
        public async Task<string> Login(LoginDTO loginDTO)
        {
            AppUser user = await _accountRepository.GetUserByEmailOrUsernameAsync(loginDTO.UsernameOrPassword);

            if (user is null) return null;

            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password)) return null;

            string token = _tokenService.GenerateJwtToken(user.Email, user.UserName);

            return token;
        }

        public async Task<bool> Register(RegisterDTO registerDTO)
        {
            AppUser appUser = new()
            {
                UserName=registerDTO.Username,
                Email=registerDTO.Email,
                PhoneNumber=registerDTO.PhoneNumber,

            };


            var result =  await _accountRepository.Register(appUser, registerDTO.Password);
            return result;
        }
        
    }
}
