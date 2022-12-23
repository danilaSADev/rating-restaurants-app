using RestaurantRatingsApp.Data.Models;

namespace RestaurantRatingsApp.Data.Interfaces;

public interface IRestaurantsFeedbacksRepository
{
    void Create(RestaurantFeedback model);
    Task<RestaurantFeedback> Read(long id);
    double GetRatingForRestaurant(long id);
    IEnumerable<RestaurantFeedback> GetFeedbacksByRestaurant(Restaurant restaurant);
    void Update(RestaurantFeedback model);
    Task Delete(long id);
    IEnumerable<RestaurantFeedback> ReadAll();
}