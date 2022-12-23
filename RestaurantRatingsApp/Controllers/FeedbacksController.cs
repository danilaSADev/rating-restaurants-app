using System.Net;
using System.Web.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestaurantRatingsApp.Data.Interfaces;
using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Controllers;

[Authorize]
public class FeedbacksController : Controller
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly IRestaurantsFeedbacksRepository _feedbacksRepository;
    private readonly UserManager<AppUser> _userManager;
    private IEnumerable<Restaurant> _restaurants;
    
    public FeedbacksController(
        IRestaurantsRepository restaurantsRepository, 
        IRestaurantsFeedbacksRepository feedbacksRepository,
        UserManager<AppUser> userManager)
    {
        _restaurantsRepository = restaurantsRepository;
        _feedbacksRepository = feedbacksRepository;
        _userManager = userManager;
    }
    
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Authorization.Authorize]
    public IActionResult Index()
    {
        ViewBag.Feedbacks = _feedbacksRepository.ReadAll();
        return View();
    }

    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Authorization.Authorize]
    public IActionResult Create()
    {
        _restaurants = _restaurantsRepository.ReadAll().ToList();
        ViewBag.Restaurants = _restaurants; 
        return View();
    }

    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Authorization.Authorize]
    public async Task<IActionResult> Create(RestaurantFeedback feedback)
    {
        _restaurants = _restaurantsRepository.ReadAll().ToList();
        feedback.Author = await _userManager.FindByNameAsync(User.Identity.Name);
        var id = long.Parse(Request.Form["Restaurant"].ToString());
        feedback.Restaurant = _restaurants.First(rest => rest.Id == id);
        _feedbacksRepository.Create(feedback);
        return Ok();
    }
}   