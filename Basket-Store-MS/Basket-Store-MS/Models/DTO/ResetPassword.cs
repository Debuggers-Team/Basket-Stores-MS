﻿using System.ComponentModel.DataAnnotations;

namespace Basket_Store_MS.Models.DTO
{
    public class ResetPassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
