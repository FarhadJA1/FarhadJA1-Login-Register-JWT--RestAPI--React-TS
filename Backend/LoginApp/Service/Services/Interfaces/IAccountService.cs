using Domain.Entities;
using Service.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Register(RegisterDTO registerDTO);
        Task<string> Login(LoginDTO loginDTO);        
    }
}
