using System.ComponentModel.DataAnnotations.Schema; // To use [Column].

namespace Northwind.EntityModels;

/**
 * Entity class for the Categories table.
 */
public class Category
{
    // see page 531
    // These properties map to columns in the database.
    public int CategoryId { get; set; } // Primary key

    public string CategoryName { get; set; } = null!;
    // CategoryName must not be null in DB column. We will add this constraint by Fluent API.


    [Column(TypeName = "ntext")]
    public string Description { get; set; }

    // Define a navigation property for related rows.
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    // To enable developers to add products to a category, we must
    // initialize the navigation property to an empty collection.
    // This also avoids an exception if we get a member like Count.
}
