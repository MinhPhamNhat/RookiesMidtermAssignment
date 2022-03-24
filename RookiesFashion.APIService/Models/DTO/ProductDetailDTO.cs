using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.APIService.Models.DTO;

public class ProductDetailDTO
{
    public Product Product { get; set; }
    public PagedModelDto<Rating> PagedRating { get; set; }

    public List<int> CountRating { get; set; }

    public List<double> CountPercentage { get; set; }
}