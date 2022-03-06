using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.ViewModels;

public class PagedResponseVM<TViewModel1> : BaseQueryCriteriaVM
{
    public int CurrentPage { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages { get; set; }

    public IEnumerable<TViewModel1> Items { get; set; }

    public bool HasPreviousPage
    {
        get
        {
            return (Page > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (Page < TotalPages);
        }
    }
}