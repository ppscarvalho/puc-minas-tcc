using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGL.IdentityServer.Infra;
using SGL.IdentityServer.Infra.Context;

namespace SGL.IdentityServer.Infra.Context
{
    public class MySqlContext : IdentityDbContext<ApplicationUser>
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
    }
}
