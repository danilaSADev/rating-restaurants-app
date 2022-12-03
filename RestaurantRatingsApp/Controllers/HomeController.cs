using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantRatingsApp.Data.Models;
using RestaurantRatingsApp.Models;
using Microsoft.AspNetCore.Identity;

namespace RestaurantRatingsApp.Controllers;

public class HomeController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ILogger<HomeController> _logger;

    public HomeController(SignInManager<AppUser> signInManager, ILogger<HomeController> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }
    
    public async Task<IActionResult> Logout() { 
        await _signInManager.SignOutAsync(); 
        return RedirectToAction("Index", "Home"); 
    } 

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Profile()
    {
        AppUser user = User.Identity as AppUser;
        Console.WriteLine(user?.Id);
        return View(user);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}