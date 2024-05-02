using Northwind.EntityModels; // To use NorthwindDb

using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");
// Prints: "Provider: Microsoft.EntityFrameworkCore.Sqlite"

// Disposes the database context. (not implemented)