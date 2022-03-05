using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Pages.Product;
public class CollectionPageModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    public CollectionPageModel(IProductService productService, IMapper mapper, IConfiguration config)
    {
        _productService = productService;
        _mapper = mapper;
        _config = config;
    }


    [BindProperty(SupportsGet = true)]
    public List<ProductVM> product { get; set; }


    public async Task OnGet(string? sortOrder, string? searchKeyword, int? categoryId, int? rating, int? page)
    {
        var baseQuery = new BaseQueryCriteriaVM()
        {
            SortOrder = sortOrder,
            Search = searchKeyword,
            CategoryId = categoryId,
            Rating = rating,
            Page = page?? 1,
            Limit = int.Parse(_config[RequirementConstants.DEFAULT_LIMIT])
        };
        var resp = await _productService.GetProductsByQuery(baseQuery);
    }

    public async Task<IActionResult> OnGetWithFilterAsync()
    {

        return Page();
    }

}