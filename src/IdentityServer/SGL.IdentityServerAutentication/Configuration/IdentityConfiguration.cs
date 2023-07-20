using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace SGL.IdentityServerAutentication.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "admin";
        public const string Client = "client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
               new ApiScope("sistema_gestao_loja", "SGL Server"),
               new ApiScope("read", "Read Data"),
               new ApiScope("write", "Write Data"),
               new ApiScope("delete", "Delte Daya")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("sistema_gestao_loja_secreto".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "sistema_gestao_loja",
                    ClientSecrets = {new Secret("sistema_gestao_loja_secreto".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:7080/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:7080/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "sistema_gestao_loja"
                    }
                }
            };

    }
}
