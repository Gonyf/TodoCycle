using System;
using System.Security.Claims;
using TodoCycle.Models;

namespace TodoCycle.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Name);
        }
        
        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            return int.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        
        public static User GetUser(this ClaimsPrincipal claimsPrincipal)
        {
            return new User
            {
                Username = GetUsername(claimsPrincipal),
                Id = GetId(claimsPrincipal)
            };
        }
    }
}
