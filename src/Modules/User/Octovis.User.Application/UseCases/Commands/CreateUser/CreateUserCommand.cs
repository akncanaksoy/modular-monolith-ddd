using MediatR;
using Octovis.SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Application.UseCases.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public TimeZoneType TimeZone { get; set; }
        public LanguageCodeType LanguageCode { get; set; }
        public Guid RoleId { get; set; }

        public CreateUserCommand(string username, string passwordHash, string email, string phone, TimeZoneType timeZone, LanguageCodeType languageCode, Guid roleId )
        {
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            Phone = phone;
            TimeZone = timeZone;
            LanguageCode = languageCode;
            RoleId = roleId;
        }
    }
}
