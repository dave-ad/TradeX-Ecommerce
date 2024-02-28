﻿namespace TradeXEcommerce.Shared.DTO;

public class LoginDTO
{
    [Required, EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}