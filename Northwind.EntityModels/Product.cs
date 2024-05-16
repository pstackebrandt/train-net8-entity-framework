using System.ComponentModel.DataAnnotations; // To use [Required].
using System.ComponentModel.DataAnnotations.Schema; // To use [Column].

namespace Northwind.EntityModels;

/**
 * Entity class for the Products table.
 */
public class Product
{
    //  (see page 531)

    public int ProductId { get; set; } // Primary key

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    // "Property name is different from the column name."
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }

    [Column("UnitsInStock")]
    public short? Stock { get; set; }

    public bool Discontinued { get; set; }

    // These two properties define the foreign key relationship
    // to the Categories table.
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!; // Reference to the related entity
}
