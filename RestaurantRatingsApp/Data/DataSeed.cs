using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data;


/// <summary>
/// Generates automatically all the needed data at the DB initialization
/// </summary>
public static class ModelBuilderExtensions
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        string[] roles = { "Owner", "Administrator", "Moderator", "User"};

        foreach (string role in roles)
        {        
            var roleStore = new RoleStore<IdentityRole>(context);
            if (!context.Roles.AnyAsync(r => r.Name == role).Result)
            {
                roleStore.CreateAsync(new IdentityRole(role));
            }
        }

        var user = new AppUser()
        {
            Email = "danilasadev@example.com",
            NormalizedEmail = "DANILASADEV@EXAMPLE.COM",
            UserName = "danilasadev",
            NormalizedUserName = "DANILASADEV",
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };


        if (!context.Users.Any(u => u.UserName == user.UserName))
        {
            var password = new PasswordHasher<AppUser>();
            var hashed = password.HashPassword(user,"sec1234");
            user.PasswordHash = hashed;

            var userStore = new UserStore<AppUser>(context);
            var result = userStore.CreateAsync(user);
            // Console.WriteLine(result);
        }

        AssignRoles(serviceProvider, user.Email, roles);    

        context.SaveChangesAsync();
    }

    public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
    {
        UserManager<AppUser> userManager = services.GetService<UserManager<AppUser>>();
        AppUser user = await userManager.FindByEmailAsync(email);
        var result = await userManager.AddToRolesAsync(user, roles);
        return result;
    }

}