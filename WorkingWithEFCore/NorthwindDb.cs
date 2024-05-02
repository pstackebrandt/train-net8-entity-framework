using Microsoft.EntityFrameworkCore;    // To use DbContext and more

namespace Northwind.EntityModels;

/** This manages the interaction with the Northwind database.**/
public class NorthwindDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path =  Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";
        WriteLine($"connectionString: {connectionString}");
        optionsBuilder.UseSqlite(connectionString);
    }
}
