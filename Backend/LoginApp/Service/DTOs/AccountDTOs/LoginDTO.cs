using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.AccountDTOs
{
    public class LoginDTO
    {
        [Required]
        public string UsernameOrPassword { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
