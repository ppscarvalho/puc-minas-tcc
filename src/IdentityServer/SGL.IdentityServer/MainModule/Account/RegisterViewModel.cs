#nullable disable

using IdentityServerHost.Quickstart.UI;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.IdentityServer.MainModule.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Permissão de Acesso")]
        public string RoleName { get; set; }

        public bool AllowRememberLogin { get; set; } = true;
        public bool EnableLocalLogin { get; set; } = true;

        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
    }
}
