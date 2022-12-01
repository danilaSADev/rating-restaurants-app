namespace RestaurantRatingsApp.Data.Models;

public class RestaurantFeedback
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Header { get; set; } = string.Empty;
    public int Rating { get; set; }
}