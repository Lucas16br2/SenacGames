using System;
using System.Collections.Generic;
using System.Text;

//DTOs usados nos endpoints de autenticação( login e registro de usuário )

namespace SenacGames.Application.DTOs
{
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
    public class RegisterDto 
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassWord { get; set; } = string.Empty;
    }
    public class UserDto
    {
        public string id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IList<string> roles { get; set; } = new List<string>();

    }
}
