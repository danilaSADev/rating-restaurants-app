using System.ComponentModel.DataAnnotations;

namespace RestaurantRatingsApp.Data.Models;

public class RestaurantFeedback
{
    [Key] public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Header { get; set; } = string.Empty;
    public int Rating { get; set; }
    public AppUser Author { get; set; }
    public Restaurant Restaurant { get; set; }
}