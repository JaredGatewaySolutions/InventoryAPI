global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;

namespace InventoryAPI;

public class ApplicationDbContext : IdentityDbContext<AppIdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public ApplicationDbContext() : base() { }
    public DbSet<CategoryViewModel> Category { get; set; }
    public DbSet<CustomerViewModel> Customer { get; set; }
    public DbSet<ModelViewModel> ModelType { get; set; }
    public DbSet<PartViewModel> Part { get; set; }
    public DbSet<StoreViewModel> Store { get; set; }
    public DbSet<WarehouseViewModel> Warehouse { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Define FKs and constraints for DB here, skip for now
        //builder.Entity<PartViewModel>().HasKey(x => x.ModelId);
    }
}