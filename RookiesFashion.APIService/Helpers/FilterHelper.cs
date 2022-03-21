using System.Linq.Expressions;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.APIService.Helpers;

public static class FilterHelper
{


    public static bool isProductValid(Product product, ProductBaseQueryCriteriaDto baseQueryCriteria)
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

    public static IQueryable<Product> ProductFilter(
        IQueryable<Product> productQuery,
        ProductBaseQueryCriteriaDto baseQueryCriteriaDto)
    {
        if (baseQueryCriteriaDto.CategoryId != null && baseQueryCriteriaDto.CategoryId > 0)
            productQuery = productQuery.Where(p =>
            p.CategoryId == baseQueryCriteriaDto.CategoryId ||
            p.Category.ParentCategoryId == baseQueryCriteriaDto.CategoryId);
        if (baseQueryCriteriaDto.Rating != null && baseQueryCriteriaDto.Rating > 0)
            productQuery = productQuery.Where(p => p.Ratings.Select(r => r.RatingVal).Average() >= baseQueryCriteriaDto.Rating);
        if (!string.IsNullOrEmpty(baseQueryCriteriaDto.Search))
            productQuery = productQuery.Where(p => p.Name.ToLower().Contains(baseQueryCriteriaDto.Search.ToLower()));
        productQuery = FilterHelper.ParseProductOrder(productQuery, baseQueryCriteriaDto.SortOrder);
        return productQuery;
    }

    public static IQueryable<Product> ParseProductOrder(IQueryable<Product> productQuery, ProductSortConstants? sortOrder)
    {
        switch (sortOrder)
        {
            case ProductSortConstants.NAME_ASC:
                return productQuery.OrderBy(p => p.Name);
            case ProductSortConstants.NAME_DESC:
                return productQuery.OrderByDescending(p => p.Name);
            case ProductSortConstants.PRICE_ASC:
                return productQuery.OrderBy(p => p.Price);
            case ProductSortConstants.PRICE_DESC:
                return productQuery.OrderByDescending(p => p.Price);
            case ProductSortConstants.RATING_ASC:
                return productQuery.OrderBy(p => p.Ratings.Select(r => r.RatingVal).Average());
            case ProductSortConstants.RATING_DESC:
                return productQuery.OrderByDescending(p => p.Ratings.Select(r => r.RatingVal).Average());
            case ProductSortConstants.CREATED_DATE_ASC:
                return productQuery.OrderBy(p => p.CreatedDate);
            case ProductSortConstants.CREATED_DATE_DESC:
                return productQuery.OrderByDescending(p => p.CreatedDate);
            default:
                return productQuery;
        }
    }

    public static IQueryable<Category> CategoryFilter(
        IQueryable<Category> categoryQuery,
        CategoryBaseQueryCriteriaDto baseQueryCriteriaDto)
    {
        if (baseQueryCriteriaDto.IsParent != null)
            categoryQuery = categoryQuery.Where(c => c.IsParent == baseQueryCriteriaDto.IsParent);
        if (!string.IsNullOrEmpty(baseQueryCriteriaDto.Search))
            categoryQuery = categoryQuery.Where(c => c.Name.ToLower().Contains(baseQueryCriteriaDto.Search.ToLower()));
        categoryQuery = FilterHelper.ParseCategoryOrder(categoryQuery, baseQueryCriteriaDto.SortOrder);
        return categoryQuery;
    }
    public static IQueryable<Category> ParseCategoryOrder(IQueryable<Category> categoryQuery, CategorySortConstants? sortOrder)
    {
        switch (sortOrder)
        {
            case CategorySortConstants.NAME_ASC:
                return categoryQuery.OrderBy(p => p.Name);
            case CategorySortConstants.NAME_DESC:
                return categoryQuery.OrderByDescending(p => p.Name);
            default:
                return categoryQuery;
        }
    }
}