#nullable disable
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extension;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductsController(
            IProductService productService,
            IColorService colorService,
            ISizeService sizeService,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _productService = productService;
            _colorService = colorService;
            _sizeService = sizeService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            ServiceResponse serResp = await _productService.GetProducts();
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            ServiceResponse serResp = await _productService.GetProductById(id);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, [FromForm] ProductFormDTO formProduct)
        {
            if (id != formProduct.ProductId)
            {
                return MyApiHelper.ValidationFailedResponseMessage("id", id, "Id not match", HttpContext);
            }

            if (!validateSomeOfProperties(formProduct, out ValidationResultModel validationResult))
            {
                return MyApiHelper.ValidationResponseMessage(validationResult, HttpContext);
            }

            var product = _mapper.Map<Product>(formProduct);

            ServiceResponse serResp = await _productService.UpdateProduct(product);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromForm] ProductFormDTO formProduct)
        {
            if (!validateSomeOfProperties(formProduct, out ValidationResultModel validationResult))
                return MyApiHelper.ValidationResponseMessage(validationResult, HttpContext);

            var product = _mapper.Map<Product>(formProduct);

            ServiceResponse serResp = await _productService.InsertProduct(product);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            ServiceResponse serResp = await _productService.DeleteProduct(id);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }
        private bool validateSomeOfProperties(ProductFormDTO formProduct, out ValidationResultModel validationResult)
        {
            validationResult = new ValidationResultModel();
            return validateCategory(formProduct.CategoryId, out validationResult) &&
                validateSizes(formProduct.SizeIds, out validationResult) &&
                validateColors(formProduct.ColorIds, out validationResult);

        }
        private bool validateCategory(int CategoryId, out ValidationResultModel validationState)
        {
            validationState = new ValidationResultModel();
            if (!_categoryService.IsExist(CategoryId))
            {
                validationState = new ValidationResultModel(new ValidationError("CategoryId", CategoryId, "Category not found"));
                return false;
            }
            return true;
        }

        private bool validateColors(List<int> colorIds, out ValidationResultModel validationState)
        {
            validationState = new ValidationResultModel();
            foreach (var colorId in colorIds)
            {
                if (!_colorService.IsExist(colorId, out _))
                {
                    validationState = new ValidationResultModel(new ValidationError("ColorId", colorIds, $"ColorId {colorId} not found"));
                    return false;
                }
            }
            return true;
        }

        private bool validateSizes(List<int> sizeIds, out ValidationResultModel validationState)
        {
            validationState = new ValidationResultModel();
            foreach (var sizeId in sizeIds)
            {
                if (!_sizeService.IsExist(sizeId, out _))
                {
                    validationState = new ValidationResultModel(new ValidationError("SizeId", sizeId, $"SizeId {sizeId} not found"));
                    return false;
                }
            }
            return true;
        }
    }
}
