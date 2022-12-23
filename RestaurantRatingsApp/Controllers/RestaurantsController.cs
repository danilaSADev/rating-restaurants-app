using Microsoft.AspNetCore.Mvc;
using RestaurantRatingsApp.Data.Interfaces;
using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Controllers;

[Controller]
public class RestaurantsController : Controller
{
    private readonly IRestaurantsFeedbacksRepository _feedbackRepository;
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<RestaurantsController> _logger;

    public RestaurantsController(
        IRestaurantsFeedbacksRepository feedbackRepository, 
        IRestaurantsRepository restaurantsRepository, 
        ILogger<RestaurantsController> logger)
    {
        _feedbackRepository = feedbackRepository;
        _restaurantsRepository = restaurantsRepository;
        _logger = logger;
    }
    
    [HttpGet, Microsoft.AspNetCore.Authorization.Authorize]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet, Microsoft.AspNetCore.Authorization.Authorize]
    public IActionResult DetailsForRestaurant(Restaurant restaurant)
    {
        ViewBag.Restaurant = restaurant;
        ViewBag.Feedbacks = _feedbackRepository.GetFeedbacksByRestaurant(restaurant);
        return View();
    }

    [HttpGet, Microsoft.AspNetCore.Authorization.Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, Microsoft.AspNetCore.Authorization.Authorize]
    public IActionResult Create(Restaurant restaurant)
    {
        _restaurantsRepository.Create(restaurant);
        return RedirectToAction("Index", "Restaurants");
    }
}