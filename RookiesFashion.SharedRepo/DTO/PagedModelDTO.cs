namespace RookiesFashion.SharedRepo.DTO;
public class PagedModelDto<TModel>
{
    const int MaxPageSize = 50;
    private int _pageSize;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public int CurrentPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IList<TModel> Items { get; set; }

    public PagedModelDto()
    {
        Items = new List<TModel>();
    }
}