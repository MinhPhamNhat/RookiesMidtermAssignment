
using Microsoft.AspNetCore.Mvc;
using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.Pages.Components;

public class ProductItem : ViewComponent
{
    public IViewComponentResult Invoke(ProductVM product)
    {
        return View<ProductVM>(product);
    }
}