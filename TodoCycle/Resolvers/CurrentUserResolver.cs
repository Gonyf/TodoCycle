using TodoCycle.Extensions;
using TodoCycle.Interfaces;
using TodoCycle.Models;
using Microsoft.AspNetCore.Http;

namespace TodoCycle.Resolvers
{
    public class CurrentUserResolver : ICurrentUserResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User Get()
        {
            var user = _httpContextAccessor.HttpContext.User.GetUser();
            return user;
        }
    }
}
