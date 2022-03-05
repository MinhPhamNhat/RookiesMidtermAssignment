using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.APIService.Helpers;

public static class FilterHelper
{
    public static bool ProductMatch(Product product, BaseQueryCriteriaDTO baseQueryCriteria)
    {
        bool isMatch = true;
        if (baseQueryCriteria.CategoryId != null)
        {
            if (product.CategoryId != baseQueryCriteria.CategoryId)
            {
                isMatch = false;
            }
        }
        if (baseQueryCriteria.Rating != null)
        {
            if (product.AvgRating < baseQueryCriteria.Rating)
            {
                isMatch = false;
            }
        }
        if (baseQueryCriteria.Search != null)
        {
            if (!product.Name.ToLower().Contains(baseQueryCriteria.Search.ToLower()))
            {
                isMatch = false;
            }
        }
        return isMatch;
    }

    public static int ParseProductOrder(Product a, Product b, SortConstants sortOrder){
        switch(sortOrder){
            case SortConstants.NAME_ASC:
                return a.Name.CompareTo(b.Name);
            case SortConstants.NAME_DESC:
                return b.Name.CompareTo(a.Name);
            case SortConstants.PRICE_ASC:
                return a.Name.CompareTo(b.Name);
            case SortConstants.PRICE_DESC:
                return b.Name.CompareTo(a.Name);
            case SortConstants.RATING_ASC:
                return a.AvgRating.CompareTo(b.AvgRating);
            case SortConstants.RATING_DESC:
                return b.AvgRating.CompareTo(a.AvgRating);
            default:
                return 0;

        }
    }
}