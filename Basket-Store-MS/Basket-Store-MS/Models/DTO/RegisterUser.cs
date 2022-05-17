﻿using System.ComponentModel.DataAnnotations;

namespace Basket_Store_MS.Models.DTO
{
    public class RegisterUser
    {
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}