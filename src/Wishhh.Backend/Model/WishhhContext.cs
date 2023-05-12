using Microsoft.EntityFrameworkCore;
using Wishhh.Backend.Model.Users;

namespace Wishhh.Backend.Model;

public sealed class WishhhContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Wishlist> Wishlists { get; set; } = null!;
    public DbSet<Wish> Wishes { get; set; } = null!;

    public WishhhContext(DbContextOptions<WishhhContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .ToTable("users");
        
        modelBuilder.Entity<Wishlist>()
            .ToTable("wishlists");
        
        modelBuilder.Entity<Wish>()
            .ToTable("wishes");
    }
}