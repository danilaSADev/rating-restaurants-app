using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RestaurantRatingsApp.Data.Models;

public class Restaurant
{
    [Key] public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string ShortDescription { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
}