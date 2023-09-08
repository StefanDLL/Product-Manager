using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Manager.Domain;

[Index(nameof(SKU), IsUnique = true)]

public class Product
{
    public int Id { get; set; }

    [MaxLength(50)]

    public string Name { get; set; }

    [Column(TypeName = "nchar(6)")]

    public string SKU { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public int Price { get; set; }
}
