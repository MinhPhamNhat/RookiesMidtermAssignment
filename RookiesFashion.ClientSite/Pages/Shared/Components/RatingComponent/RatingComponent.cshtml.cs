
using Microsoft.AspNetCore.Mvc;
using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.Pages.Components;

public class RatingComponent : ViewComponent
{
    public IViewComponentResult Invoke(RatingVM rating)
    {
        return View<RatingVM>(rating);
    }
}