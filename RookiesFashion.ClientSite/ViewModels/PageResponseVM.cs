using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.ViewModels;

public class PagedResponseVM<TViewModel1> : BaseQueryCriteriaVM
{
    public PagedResponseVM(int currentPage, int totalItems, int totalPages)
    {
        this.CurrentPage = currentPage;
        this.TotalItems = totalItems;
        this.TotalPages = totalPages;

    }
    public int CurrentPage { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages { get; set; }

    public IEnumerable<TViewModel1> Items { get; set; }

    public bool HasPreviousPage
    {
        get
        {
            return (CurrentPage > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (CurrentPage < TotalPages);
        }
    }

    public List<int> PageRange
    {
        get
        {
            var maxPage = TotalPages>=5?5:TotalPages;
            if (CurrentPage - 2 <= 0)
            {
                return Enumerable.Range(1, maxPage).ToList();
            }
            else
            {
                return Enumerable.Range(CurrentPage-2, maxPage).ToList();
            }
        }
    }
}