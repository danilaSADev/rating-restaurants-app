using RestaurantRatingsApp.Data.Interfaces;
using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data.Repositories;

// TODO : Imlement repository methods
public class RestaurantsRepository : IRestaurantsRepository
{
    public void Create(Restaurant model)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant> Read(long id)
    {
        throw new NotImplementedException();
    }

    public void Update(Restaurant model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Restaurant> ReadAll()
    {
        throw new NotImplementedException();
    }
}