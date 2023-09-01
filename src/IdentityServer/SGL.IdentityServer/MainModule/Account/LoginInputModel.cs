// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.
#nullable disable

using System.ComponentModel.DataAnnotations;

namespace IdentityServerHost.Quickstart.UI
{
    public class LoginInputModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Display(Name = "Manter autenticado")]
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}