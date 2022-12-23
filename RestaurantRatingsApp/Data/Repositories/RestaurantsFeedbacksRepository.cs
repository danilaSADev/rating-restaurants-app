using Microsoft.EntityFrameworkCore;
using RestaurantRatingsApp.Data.Interfaces;
using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data.Repositories;

public class RestaurantsFeedbacksRepository : IRestaurantsFeedbacksRepository
{
    private readonly ApplicationDbContext _context;
    
    public RestaurantsFeedbacksRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(RestaurantFeedback model)
    {
        _context.Feedbacks.AddAsync(model);
        _context.SaveChangesAsync();
    }

    public async Task<RestaurantFeedback> Read(long id)
    {
        return await _context.Feedbacks.FirstAsync(m => m.Id == id);
    }

    public double GetRatingForRestaurant(long id)
    {
        Restaurant restaurant = _context.Restaurants.First(r => r.Id == id);
        return _context.Feedbacks
            .Where(r => r.Id == restaurant.Id)
            .ToList()
            .Average(r => r.Rating);
    }
    
    public IEnumerable<RestaurantFeedback> GetFeedbacksByRestaurant(Restaurant restaurant)
    {
        return _context.Feedbacks.Where(feedback => feedback.Restaurant.Id == restaurant.Id).ToList();
    }

    public void Update(RestaurantFeedback model)
    {
        _context.Feedbacks.Update(model);
        _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var entity = await Read(id);
        _context.Feedbacks.Remove(entity);
    }

    public IEnumerable<RestaurantFeedback> ReadAll()
    {
        var entities = from m in _context.Feedbacks select m;
        return entities;
    }
}