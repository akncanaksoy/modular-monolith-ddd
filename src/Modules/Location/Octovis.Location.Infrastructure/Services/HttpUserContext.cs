using Microsoft.AspNetCore.Http;
using Octovis.Location.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Infrastructure.Services
{
    public class HttpUserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public string Username => _httpContextAccessor.HttpContext.User.Identity.Name;

        public List<string> Claims => _httpContextAccessor.HttpContext.User.Claims
                                      .Where(c => c.Type == ClaimTypes.Role || c.Type == "permission")
                                      .Select(c => c.Value)
                                      .ToList();

       
        public bool HasClaim(string claimName) => Claims.Contains(claimName);
    }

}
