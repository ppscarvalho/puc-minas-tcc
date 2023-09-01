﻿using IdentityModel;
using Microsoft.AspNetCore.Identity;
using SGL.IdentityServer.Application.Configuration;
using SGL.IdentityServer.Infrastructure.Context;
using System.Security.Claims;

namespace SGL.IdentityServer.Infrastructure.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySQLContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role)
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
                LastName = "Administrador"
            };

            _user.CreateAsync(admin, "Ap&xStrong2@23").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin,
                IdentityConfiguration.Admin).GetAwaiter().GetResult();
            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new()
            {
                UserName = "joao-operador",
                Email = "pedro_c_2022@outlook.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (91) 99251-1848",
                FirstName = "João",
                LastName = "Operador"
            };

            _user.CreateAsync(client, "Ap&xStrong2@23").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client,
                IdentityConfiguration.Client).GetAwaiter().GetResult();
            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
