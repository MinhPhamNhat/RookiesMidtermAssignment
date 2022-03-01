using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.ClientSite.Models;

namespace RookiesFashion.ClientSite.ViewModels;
public class RatingVM
{
    public int RatingId { get; set; }

    public int RatingVal { get; set; }

    public int RatingProductId { get; set; }
    public ProductVM? Product { get; set; }

    public int RatingUserId { get; set; }
    public UserVM? UserRating { get; set; }
}