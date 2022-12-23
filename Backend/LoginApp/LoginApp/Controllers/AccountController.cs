using Microsoft.AspNetCore.Mvc;
using Service.DTOs.AccountDTOs;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;            
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            if (registerDto is not null && registerDto.Password==registerDto.ConfirmPassword)
            {
               var result = await _accountService.Register(registerDto);
                if (result) 
                    return Ok("Registration successfully completed");
                return BadRequest("Something went wrong");
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        [Route("Login")]
        public async Task<string> Login([FromBody] LoginDTO loginDto)
        {
            return await _accountService.Login(loginDto);
        }
    }
}
