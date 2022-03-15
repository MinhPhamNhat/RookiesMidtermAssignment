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
using RookiesFashion.SharedRepo.DTO;

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
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public ProductsController(
            IProductService productService,
            IColorService colorService,
            ISizeService sizeService,
            ICategoryService categoryService,
            IMapper mapper,
            IConfiguration config)
        {
            _productService = productService;
            _colorService = colorService;
            _sizeService = sizeService;
            _categoryService = categoryService;
            _mapper = mapper;
            _config = config;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] BaseQueryCriteriaDTO baseQuery, CancellationToken cancellationToken)
        {
            ServiceResponse serResp = await _productService.GetPagedProductFilter(baseQuery, cancellationToken);
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
        public async Task<ActionResult> PostProduct([FromForm] List<IFormFile> Files, [FromForm] IFormCollection formCollection)
        {
            ProductFormDTO formProduct = ProductFormDTOBinder(formCollection, Files);
            if (TryValidateModel(formProduct))
            {
                if (!validateSomeOfProperties(formProduct, out ValidationResultModel validationResult))
                    return MyApiHelper.ValidationResponseMessage(validationResult, HttpContext);

                var product = _mapper.Map<Product>(formProduct);

                ServiceResponse serResp = await _productService.InsertProduct(product);
                return MyApiHelper.RequestResultParser(serResp, HttpContext);
            }
            return MyApiHelper.ValidationResponseMessage(new ValidationResultModel(ModelState), HttpContext);
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
        private bool validateCategory(int? CategoryId, out ValidationResultModel validationState)
        {
            validationState = new ValidationResultModel();
            if (!_categoryService.IsExist((int)CategoryId))
            {
                validationState = new ValidationResultModel(new ValidationError("CategoryId", CategoryId, "Category not found"));
                return false;
            }
            return true;
        }

        private bool validateColors(List<int> colorIds, out ValidationResultModel validationState)
        {
            validationState = new ValidationResultModel();
            if (colorIds.Count() <= 0)
            {
                validationState = new ValidationResultModel(new ValidationError("ColorId", colorIds, $"Please select color"));
                return false;
            }
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
            if (sizeIds.Count() <= 0)
            {
                validationState = new ValidationResultModel(new ValidationError("SizeIds", sizeIds, $"Please select size"));
                return false;
            }
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

        private ProductFormDTO ProductFormDTOBinder(IFormCollection formCollection, List<IFormFile> files)
        {
            ProductFormDTO productFormDTO = new ProductFormDTO();
            productFormDTO.CategoryId = int.Parse(formCollection["CategoryId"].First());
            productFormDTO.Description = formCollection["Description"].First();
            productFormDTO.Name = formCollection["Name"].First();
            productFormDTO.Price = int.Parse(formCollection["Price"].First());
            productFormDTO.ColorIds = formCollection["ColorIds[]"].Select(_ => int.Parse(_)).ToList();
            productFormDTO.SizeIds = formCollection["SizeIds[]"].Select(_ => int.Parse(_)).ToList();
            productFormDTO.Files = files;
            return productFormDTO;
        }
    }
}
