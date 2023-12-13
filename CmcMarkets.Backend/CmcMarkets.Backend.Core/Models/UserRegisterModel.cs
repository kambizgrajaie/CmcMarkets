using CmcMarkets.Backend.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CmcMarkets.Backend.Core.Model
{
    public class UserRegisterModel
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
