using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SGL.IdentityServerAutentication.Infra.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySqlContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new()
            {
                UserName = "pedro-admin",
                Email = "ppscarvalho@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (91) 99251-1848",
                FirstName = "Pedro",
                LastName = "Admin"
            };

            _user.CreateAsync(admin, "Ap&xStrong2@23").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();
            _ = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new()
            {
                UserName = "pedro-client",
                Email = "pedro_c_2022@outlook.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (91) 99251-1848",
                FirstName = "Pedro",
                LastName = "Client"
            };

            _user.CreateAsync(client, "Ap&xStrong2@23").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();
            _ = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
