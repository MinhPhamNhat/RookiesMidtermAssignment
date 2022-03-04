using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Helpers;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly ILogger<IndexModel> _logger;
    public IndexModel(ILogger<IndexModel> logger, IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
        _logger = logger;
    }


    [BindProperty(SupportsGet = true)]
    public List<ProductVM> products { get; set; }


    // public async Task OnGetProductCategoryName(string categorynameclient)
    // {
    //     var productDto = await _productService.GetProductByCategoryAndPageAsync(categorynameclient);
    //     PagedResponseVM = _mapper.Map<PagedResponseVM<ProductVM>>(productDto);
    //     await ShowCategoryName();
    // }
    public async Task OnGetAsync()
    {
        Console.WriteLine(11111 + "");
        var resp = await _productService.GetProducts();
        var data = MyResponseMapper.MapJsonToList<RookiesFashion.ClientSite.Models.Product>((JsonElement)resp.Data);
        products = data.Select(d => _mapper.Map<ProductVM>(d)).ToList();
    }

}