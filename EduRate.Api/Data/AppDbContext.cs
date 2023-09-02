using EduRate.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace EduRate.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Your DbSet properties go here. For example:
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Interaction> Interactions { get; set; }
    public DbSet<Rating> Ratings { get; set; }


}