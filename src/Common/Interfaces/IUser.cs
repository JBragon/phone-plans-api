using System.Collections.Generic;
using System.Security.Claims;

namespace JBragon.Common.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        string Token { get; }
        string GetUserName();
        string GetEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
