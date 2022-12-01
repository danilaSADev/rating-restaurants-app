using Microsoft.EntityFrameworkCore;
using RestaurantRatingsApp.Data;
using RestaurantRatingsApp.Data.Interfaces;
using RestaurantRatingsApp.Data.Models;
using RestaurantRatingsApp.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// todo : how to place connection string here?
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddMemoryCache();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IRestaurantsFeedbacksRepository, RestaurantsFeedbacksRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=restauraunts;Username=postgres;Password=rootPass@1234"));

builder.Services
    .AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
// app.Services.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.MapRazorPages();

app.Run();