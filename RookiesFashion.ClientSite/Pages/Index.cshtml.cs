using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.DTO;
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
    
    public async Task OnGetAsync()
    {
        
        foreach(var claim in User.Claims){
            Console.WriteLine(claim.Type);
        }
        var productResp = await _productService.GetProducts();
        var pagedProducts = MyResponseMapper.MapJson<PagedModelDto<Product>>((JsonElement)productResp.Data);
        products = _mapper.Map<PagedResponseVM<ProductVM>>(pagedProducts).Items.ToList();
    }

}