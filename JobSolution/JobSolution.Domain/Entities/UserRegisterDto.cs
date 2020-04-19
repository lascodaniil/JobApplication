using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Domain.Entities
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleFromRegister { get; set; }
        public string Base64Photo { get; set; }

    }
}
