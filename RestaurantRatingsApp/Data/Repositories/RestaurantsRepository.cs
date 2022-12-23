using Microsoft.EntityFrameworkCore;
using RestaurantRatingsApp.Data.Interfaces;
using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data.Repositories;

public class RestaurantsRepository : IRestaurantsRepository
{
    private readonly ApplicationDbContext _context;

    public RestaurantsRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Restaurant model)
    {
        _context.Restaurants.AddAsync(model);
        _context.SaveChangesAsync();
    }

    public async Task<Restaurant> Read(long id)
    {
        return await _context.Restaurants.FirstAsync(m => m.Id == id);
    }

    public void Update(Restaurant model)
    {
        _context.Restaurants.Update(model);
        _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var entity = await Read(id);
        _context.Restaurants.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Restaurant> ReadAll()
    {
        var entities = from m in _context.Restaurants select m;
        return entities;
    }
}