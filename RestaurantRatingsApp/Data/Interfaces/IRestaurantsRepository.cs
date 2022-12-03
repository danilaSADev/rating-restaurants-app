using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data.Interfaces;

public interface IRestaurantsRepository
{
    void Create(Restaurant model);
    Task<Restaurant> Read(long id);
    void Update(Restaurant model);
    Task Delete(long id);
    IQueryable<Restaurant> ReadAll();
}