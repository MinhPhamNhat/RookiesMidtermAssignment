using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.ViewModels;
public class ProductDetailVM : ProductVM
{
    public int CountRating(int val) => Ratings.Where(r=>r.RatingVal == val).Count(); 

    public double CalPercentage(int val) => (double)CountRating(val)/Ratings.Count()*100;
}