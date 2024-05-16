using Microsoft.EntityFrameworkCore;    // To use DbContext and more

// ReSharper disable once CheckNamespace
namespace Northwind.EntityModels;

/** This manages the interaction with the Northwind database.**/
public class NorthwindDb : DbContext
{
    // These two properties map to the tables in the database.
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connect to database
        var databaseFile = "Northwind.db";
        var path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        var connectionString = $"Data Source={path}";
        WriteLine($"connectionString: {connectionString}");
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // page 533

        // Example of using Fluent API instead of attributes
        // to limit the length of a category name to 15 characters.
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // Not null
            .HasMaxLength(15);

        // Some SQLite-specific configuration

        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            // To "fix" the lack of decimal support in SQLite
            modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        }
    }
}
