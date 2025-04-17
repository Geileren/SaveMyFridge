using Microsoft.EntityFrameworkCore;
using SaveMyFridge.Lib.Models;

namespace SaveMyFridge.Api.Data;

public class SaveMyFridgeDbContext : DbContext
{
    public SaveMyFridgeDbContext(DbContextOptions options) : base(options) { }

    // Setting up the Db entities 
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
}