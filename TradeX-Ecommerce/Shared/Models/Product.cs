﻿namespace TradeXEcommerce.Shared.Models;

public class Product
{
    public int Id { get; set; }

    [Required, StringLength(50, MinimumLength = 6)]
    public string? Name { get; set; }

    [Required, DataType(DataType.Currency)]
    public double OriginalPrice { get; set; }

    [DataType(DataType.Currency)]
    public double NewPrice { get; set; }

    [Required, StringLength(1000, MinimumLength = 10)]
    public string? Description { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string? Image { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime UploadedDate { get; set; } = DateTime.Now;

    //Relationship : many to one
    public Category? Category { get; set; }
    //public int CategoryId { get; set; } = 1;
    public int CategoryId { get; set; }
}