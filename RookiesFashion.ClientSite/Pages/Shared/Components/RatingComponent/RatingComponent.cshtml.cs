
using Microsoft.AspNetCore.Mvc;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.Pages.Components;

public class RatingComponent : ViewComponent
{
    public IViewComponentResult Invoke(Rating rating)
    {
        return View<Rating>(rating);
    }
}