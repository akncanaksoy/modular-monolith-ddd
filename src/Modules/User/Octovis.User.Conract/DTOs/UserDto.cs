using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Conract.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }


        public UserDto ConvertUserDto(string userName, string eMail, string passwordHash, string role)
        {
            UserName = userName;
            Email = eMail;
            PasswordHash = passwordHash;
            Role = role;

            return this;
        }

    }
}
