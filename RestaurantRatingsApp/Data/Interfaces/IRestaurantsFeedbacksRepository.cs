using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data.Interfaces;

public interface IRestaurantsFeedbacksRepository
{
    void Create(RestaurantFeedback model);
    Task<RestaurantFeedback> Read(long id);
    void Update(RestaurantFeedback model);
    Task Delete(long id);
    
    IQueryable<RestaurantFeedback> ReadAll();
}