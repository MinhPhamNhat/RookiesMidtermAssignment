using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Pages.Products;
public class DetailPageModel : PageModel
{
    private readonly IProductService _productService;
    private readonly IRatingService _ratingService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    public DetailPageModel(IProductService productService, IMapper mapper, IRatingService ratingService, IConfiguration config)
    {
        _productService = productService;
        _mapper = mapper;
        _ratingService = ratingService;
        _config = config;
    }


    [BindProperty]
    public ProductDetailVM product { get; set; }
    [BindProperty]
    public RatingFormVM Rating { get; set; }
    [BindProperty]
    public RatingBaseQueryCriteriaDto query { get; set; }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        var resp = await _ratingService.InsertRating(Rating);
        return Redirect(Request.Path + "#RATING_SECTION");
    }

    public async Task<IActionResult> OnGetAsync(int? id, int? pageIndex)
    {
        query = new RatingBaseQueryCriteriaDto()
        {
            Rating = 1,
            Page = pageIndex ?? 1,
            Limit = int.Parse(_config[RequirementConstants.DEFAULT_RATING_LIMIT])
        };
        var resp = await _productService.GetProductById((int)id, query);
        var data = MyResponseMapper.MapJson<ProductDetail>((JsonElement)resp.Data);
        product = _mapper.Map<ProductDetailVM>(data);
        return Page();
    }

}