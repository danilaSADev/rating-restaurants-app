using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data;

public sealed class ApplicationDbContext : IdentityDbContext
{
    public DbSet<RestaurantFeedback> Feedbacks { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // Database.EnsureCreated();
    }
}