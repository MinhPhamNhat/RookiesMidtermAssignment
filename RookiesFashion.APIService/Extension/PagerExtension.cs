using Microsoft.EntityFrameworkCore;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.APIService.Extension
{
    public static class PagerExtension
    {
        public static async Task<PagedModelDTO<TModel>> PaginateAsync<TModel>(
            this IQueryable<TModel> query,
            BaseQueryCriteriaDTO criteriaDto,
            CancellationToken cancellationToken)
            where TModel : class
        {

            var paged = new PagedModelDTO<TModel>();

            paged.CurrentPage = (criteriaDto.Page < 0) ? 1 : criteriaDto.Page;
            paged.PageSize = criteriaDto.Limit;

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;
            paged.TotalItems = await query.CountAsync(cancellationToken);
            paged.Items = await query.Skip(startRow).Take(criteriaDto.Limit)
                        .ToListAsync(cancellationToken);
            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
    }
}