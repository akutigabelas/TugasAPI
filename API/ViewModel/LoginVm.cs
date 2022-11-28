﻿using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class LoginVm
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
