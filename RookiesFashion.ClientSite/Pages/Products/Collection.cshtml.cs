using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Pages.Products;
public class CollectionPageModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    public CollectionPageModel(IProductService productService, ICategoryService categoryService, IMapper mapper, IConfiguration config)
    {
        _productService = productService;
        _categoryService = categoryService;
        _mapper = mapper;
        _config = config;
    }

    [BindProperty(SupportsGet = true)]
    public List<ProductVM> products { get; set; }
    public BaseQueryCriteriaVM baseQuery { get; set; }
    public PagedResponseVM<ProductVM> pagedResponse { get; set; }
    public List<CategoryVM> categories { get; set; }
    public async Task OnGet(string? sortOrder, string? searchKeyword, int? categoryId, int? rating, int? pageIndex)
    {
        baseQuery = new BaseQueryCriteriaVM()
        {
            SortOrder = sortOrder,
            Search = searchKeyword,
            CategoryId = categoryId,
            Rating = rating,
            Page = pageIndex ?? 1,
            Limit = int.Parse(_config[RequirementConstants.DEFAULT_LIMIT])
        };
        var productResp = await _productService.GetProductsByQuery(baseQuery);
        var pagedProducts = MyResponseMapper.MapJson<PagedModelDTO<Product>>((JsonElement)productResp.Data);
        pagedResponse = _mapper.Map<PagedResponseVM<ProductVM>>(pagedProducts);

        var categoryResp = await _categoryService.GetCategories();
        categories = MyResponseMapper.MapJsonToList<CategoryVM>((JsonElement)categoryResp.Data);
    }

    public async Task<IActionResult> OnGetWithFilterAsync()
    {
        return Page();
    }

}