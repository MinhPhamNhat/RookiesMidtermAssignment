using System.Linq.Expressions;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.APIService.Helpers;

public static class FilterHelper
{

    public static Expression<Func<Product, bool>> IsValid(BaseQueryCriteriaDTO baseQueryCriteria) => product => isProductValid(product, baseQueryCriteria);

    public static bool isProductValid(Product product, BaseQueryCriteriaDTO baseQueryCriteria)
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
    public static IQueryable<Product> ParseProductOrder(IQueryable<Product> productQuery, SortConstants? sortOrder)
    {
        switch (sortOrder)
        {
            case SortConstants.NAME_ASC:
                return productQuery.OrderBy(p => p.Name);
            case SortConstants.NAME_DESC:
                return productQuery.OrderByDescending(p => p.Name);
            case SortConstants.PRICE_ASC:
                return productQuery.OrderBy(p => p.Price);
            case SortConstants.PRICE_DESC:
                return productQuery.OrderByDescending(p => p.Price);
            case SortConstants.RATING_ASC:
                return productQuery.OrderBy(p => p.Ratings.Select(r => r.RatingVal).Average());
            case SortConstants.RATING_DESC:
                return productQuery.OrderByDescending(p => p.Ratings.Select(r => r.RatingVal).Average());
            case SortConstants.CREATED_DATE_ASC:
                return productQuery.OrderBy(p => p.CreatedDate);
            case SortConstants.CREATED_DATE_DESC:
                return productQuery.OrderByDescending(p => p.CreatedDate);
            default:
                return productQuery;
        }
    }
}