using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.ClientSite.ViewModels;
public class ProductDetailVM 
{
    public ProductVM Product { get; set; }
    public PagedResponseVM<Rating> PagedRating { get; set; }
    public List<int> CountRating { get; set; }

    public List<double> CountPercentage { get; set; }
}