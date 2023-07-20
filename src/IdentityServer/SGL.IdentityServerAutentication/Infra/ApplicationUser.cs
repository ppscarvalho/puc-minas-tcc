using Microsoft.AspNetCore.Identity;

namespace SGL.IdentityServerAutentication.Infra
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
