﻿namespace TradeXEcommerce.Shared.DTO;

public class LoginModel
{
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}
