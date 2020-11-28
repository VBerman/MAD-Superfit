using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAD_Superfit
{
    public class UserInfo
    {
        [EmailAddress, Required]
        public string Email { get; set; }

        [StringLength(4, MinimumLength = 4), Required]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        public string RepeatPassword { get; set; }
        
        
        
    }
}
