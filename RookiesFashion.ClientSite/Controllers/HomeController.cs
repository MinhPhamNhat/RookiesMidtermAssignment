using System.Text.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.Helpers;
using AutoMapper;
using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public HomeController(ILogger<HomeController> logger, IProductService productService, IMapper mapper)
    {
        _logger = logger;
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var resp = await _productService.GetProducts();
        var data = MyResponseMapper.MapJsonToList<Product>((JsonElement)resp.Data);
        var output = data.Select(d => _mapper.Map<ProductVM>(d));
        return View(output);
    }

    [Route("/Detail/{id}")]
    public async Task<IActionResult> Detail(string id)
    {
        var resp = await _productService.GetProductById(id);
        var data = MyResponseMapper.MapJson<Product>((JsonElement)resp.Data);
        var output = _mapper.Map<ProductVM>(data);
        return Ok(output);
    }

    [Route("/Upload")]
    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadPost(List<IFormFile> Files)
    {
        // var payload = new Dictionary<string, object>()
        // {
        //     {"Name", "Áo đẹp"},
        //     {"Description", "Ok"},
        //     {"Sizes", new [] {1,2,3}},
        //     {"Colors", new [] {1,2,3}},
        //     {"Price", 55},
        //     {"CategoryId", 2}
        // };
        // var resp = await _productService.InsertProduct(payload, Files);
        // // var data = MyResponseMapper.MapJson<Product>((JsonElement)resp.Data);
        // // var output = _mapper.Map<ProductVM>(data);
        // return Ok(resp);
        return Ok();
    }

    


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
