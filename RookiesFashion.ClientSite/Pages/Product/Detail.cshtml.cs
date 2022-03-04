using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Pages.Product;
public class DetailPageModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public DetailPageModel(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }


    [BindProperty(SupportsGet = true)]
    public ProductVM product { get; set; }


    // public async Task OnGetProductCategoryName(string categorynameclient)
    // {
    //     var productDto = await _productService.GetProductByCategoryAndPageAsync(categorynameclient);
    //     PagedResponseVM = _mapper.Map<PagedResponseVM<ProductVM>>(productDto);
    //     await ShowCategoryName();
    // }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var resp = await _productService.GetProductById((int)id);
        var data = MyResponseMapper.MapJson<RookiesFashion.ClientSite.Models.Product>((JsonElement)resp.Data);
        product = _mapper.Map<ProductVM>(data);
        return Page();
    }

}