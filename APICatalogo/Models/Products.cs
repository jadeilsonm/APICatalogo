﻿using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
[Table("Products")]
public class Product
{
   public int ProductId { get; set; }
   [Required]
   [StringLength(100)]
   public string? Name { get; set; }
   [Required]
   [StringLength(300)]
   public string? Description { get; set; }
   [Required]
   [Column(TypeName = "decimal(12,2)")]
   public decimal Price { get; set; }
   [Required]
   [StringLength(300)]
   public string? ImageUrl { get; set; }
   public float Stock { get; set; }
   public DateTime DateRegistration { get; set; }
   public int CategoryId { get; set; }
   public Category? Category { get; set; }
}