using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.ClientSite.Models;
public class ProductDetail 
{
    public Product Product { get; set; }
    public PagedModelDto<Rating> PagedRating { get; set; }
    public List<int> CountRating { get; set; }

    public List<double> CountPercentage { get; set; }
}