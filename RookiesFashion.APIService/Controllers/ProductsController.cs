#nullable disable
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;
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
        private readonly RookiesFashionContext _context;

        private readonly IProductService _productService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IImageService _imageService;
        private readonly ImageUploadHelper _imageUploadHelper;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly ICategoryService _categoryService;
        public ProductsController(
            IImageService imageService,
            RookiesFashionContext context,
            IProductService productService,
            ICloudinaryService cloudinaryService,
            ISizeService sizeService,
            ICategoryService categoryService,
            ImageUploadHelper imageUploadHelper,
            IColorService colorService)
        {
            _context = context;
            _productService = productService;
            _cloudinaryService = cloudinaryService;
            _imageService = imageService;
            _colorService = colorService;
            _sizeService = sizeService;
            _categoryService = categoryService;
            _imageUploadHelper = imageUploadHelper;
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
        public async Task<ActionResult> GetProduct(string id)
        {
            if (int.TryParse(id, out int productId))
            {
                ServiceResponse serResp = await _productService.GetProductById(productId);
                return MyApiHelper.RequestResultParser(serResp, HttpContext);
            }
            return MyApiHelper.ValidationFailedResponseMessage("Id", id, "Invalid param", HttpContext);
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(string id, [FromForm] string data, [FromForm] List<IFormFile> Files)
        {
            dynamic body = JsonConvert.DeserializeObject(data);

            if (!int.TryParse(id, out int productId))
            {
                return MyApiHelper.ValidationFailedResponseMessage("Id", id, "Invalid param", HttpContext);
            }

            if (!_productService.IsExist(productId, out Product product))
            {
                return MyApiHelper.ResponseMessage(HttpStatusCode.NotFound, new ResponseObject { Message = "Product not found " }, HttpContext);
            }

            if (FunctionsHelper.DynamicHasProperty(body, "Name"))
            {
                product.Name = Convert.ToString(body.Name);
            }

            if (FunctionsHelper.DynamicHasProperty(body, "Description"))
            {
                product.Description = Convert.ToString(body.Description);
            }

            if (FunctionsHelper.DynamicHasProperty(body, "CategoryId"))
            {
                // Validate if ProductCategoryId is number
                string stringCategoryId = Convert.ToString(body.CategoryId);
                if (!int.TryParse(stringCategoryId, out int CategoryId))
                {
                    return MyApiHelper.ValidationFailedResponseMessage("CategoryId", body.CategoryId, $"CategoryId is invalid", HttpContext);
                }
                if (!_categoryService.IsExist(CategoryId))
                {
                    return MyApiHelper.ValidationFailedResponseMessage("CategoryId", body.CategoryId, $"Category not found", HttpContext);
                }
                product.CategoryId = CategoryId;
            }

            if (FunctionsHelper.DynamicHasProperty(body, "Price"))
            {
                string stringPrice = Convert.ToString(body.Price);
                if (!int.TryParse(stringPrice, out int Price))
                {
                    return MyApiHelper.ValidationFailedResponseMessage("Price", stringPrice, $"Price is invalid", HttpContext);
                }
                product.Price = Price;
            }

            if (FunctionsHelper.DynamicHasProperty(body, "Colors"))
            {
                List<int> ColorIdList = new List<int>();
                List<Color> finalColorList = new List<Color>();
                // Validate if all colorid is number
                if (((JArray)body.Colors).Any(c => !int.TryParse(c.ToString(), out _)))
                {
                    return MyApiHelper.ValidationFailedResponseMessage("Colors", body.Colors, "Color id is invalid", HttpContext);
                }
                else
                {
                    ColorIdList = ((JArray)body.Colors).Select(c => int.Parse(c.ToString())).ToList();
                }
                // Validate if all colorId are in db
                foreach (var colorId in ColorIdList)
                {
                    if (_colorService.IsExist(colorId, out Color color))
                    {
                        finalColorList.Add(color);
                    }
                    else
                    {
                        return MyApiHelper.ValidationFailedResponseMessage("Colors", body.Colors, $"ColorId {colorId} not found", HttpContext);
                    }
                }
            }
            if (FunctionsHelper.DynamicHasProperty(body, "Sizes"))
            {
                List<int> SizeIdList = new List<int>();
                List<Size> finalSizeList = new List<Size>();
                // Validate if all sizeid is number
                if (((JArray)body.Sizes).Any(s => !int.TryParse(s.ToString(), out _)))
                {
                    return MyApiHelper.ValidationFailedResponseMessage("Sizes", body.Sizes, "Size id is invalid", HttpContext);
                }
                else
                {
                    SizeIdList = ((JArray)body.Sizes).Select(s => int.Parse(s.ToString())).ToList();
                }
                // Validate if all sizeId are in db
                foreach (var sizeId in SizeIdList)
                {
                    if (_sizeService.IsExist(sizeId, out Size size))
                    {
                        finalSizeList.Add(size);
                    }
                    else
                    {
                        return MyApiHelper.ValidationFailedResponseMessage("Sizes", body.Sizes, $"SizeId {sizeId} not found", HttpContext);
                    }
                }
            }
            if (!TryValidateModel(product))
            {
                return MyApiHelper.ResponseMessage(HttpStatusCode.BadRequest, new ResponseObject { Message = "Validation Failed", Data = new ValidationResultModel(ModelState) }, HttpContext);
            }
            if (Files.Count > 0)
            {
                if (Files.Count > (int)RequirementConstants.IMAGE_MAX_COUNT)
                {
                    return MyApiHelper.ValidationFailedResponseMessage("Files", Files, "Images must be less than 3 and larger than 0 (1)", HttpContext);
                }
                var images = await _imageUploadHelper.ImageUpload(Files);
                product.Thumbnail = images;
            }

            ServiceResponse serResp = await _productService.UpdateProduct(product);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromForm] string data, [FromForm] List<IFormFile> Files)
        {
            dynamic body = JsonConvert.DeserializeObject(data);
            List<int> ColorIdList = new List<int>();
            List<int> SizeIdList = new List<int>();
            List<Color> finalColorList = new List<Color>();
            List<Size> finalSizeList = new List<Size>();

            string Name = Convert.ToString(body.Name);
            string Description = Convert.ToString(body.Description);
            string Price = Convert.ToString(body.Price);
            string ProductCategoryId = Convert.ToString(body.CategoryId);

            // Validate number of files ( must <= 2 )
            if (Files.Count > (int)RequirementConstants.IMAGE_MAX_COUNT || Files.Count < 1)
            {
                return MyApiHelper.ValidationFailedResponseMessage("Files", Files, "Images must be less than 3 and larger than 0 (2)", HttpContext);
            }
            // Validate if all files are image
            if (!Files.All(f => f.ContentType.Contains(FunctionsHelper.GetDescription(RequirementConstants.IMAGE_TYPE))))
            {
                return MyApiHelper.ValidationFailedResponseMessage("Files", Files, "Not all file is image", HttpContext);
            }
            // Validate if all colorid is number
            if (((JArray)body.Colors).Any(c => !int.TryParse(c.ToString(), out _)))
            {
                return MyApiHelper.ValidationFailedResponseMessage("Colors", body.Colors, "Color id is invalid", HttpContext);
            }
            else
            {
                ColorIdList = ((JArray)body.Colors).Select(c => int.Parse(c.ToString())).ToList();
            }
            // Validate if all colorId are in db
            foreach (var colorId in ColorIdList)
            {
                if (_colorService.IsExist(colorId, out Color color))
                {
                    finalColorList.Add(color);
                }
                else
                {
                    return MyApiHelper.ValidationFailedResponseMessage("Colors", body.Colors, $"ColorId {colorId} not found", HttpContext);
                }
            }
            // Validate if all sizeid is number
            if (((JArray)body.Sizes).Any(s => !int.TryParse(s.ToString(), out _)))
            {
                return MyApiHelper.ValidationFailedResponseMessage("Sizes", body.Sizes, "Size id is invalid", HttpContext);
            }
            else
            {
                SizeIdList = ((JArray)body.Sizes).Select(s => int.Parse(s.ToString())).ToList();
            }
            // Validate if all sizeId are in db
            foreach (var sizeId in SizeIdList)
            {
                if (_sizeService.IsExist(sizeId, out Size size))
                {
                    finalSizeList.Add(size);
                }
                else
                {
                    return MyApiHelper.ValidationFailedResponseMessage("Sizes", body.Sizes, $"SizeId {sizeId} not found", HttpContext);
                }
            }
            // Validate if ProductCategoryId is number
            if (!int.TryParse(ProductCategoryId, out int productCategoryId))
            {
                return MyApiHelper.ValidationFailedResponseMessage("CategoryId", body.CategoryId, $"CategoryId is invalid", HttpContext);
            }
            if (!_categoryService.IsExist(productCategoryId))
            {
                return MyApiHelper.ValidationFailedResponseMessage("CategoryId", body.CategoryId, $"Category not found", HttpContext);
            }
            // Validate if Price is number
            if (!int.TryParse(Price, out int productPrice))
            {
                return MyApiHelper.ValidationFailedResponseMessage("Price", Price, $"Price is invalid", HttpContext);
            }
            Product product = new Product()
            {
                Colors = finalColorList,
                Sizes = finalSizeList,
                Name = Name,
                Price = productPrice,
                CategoryId = productCategoryId,
                Description = Description,
            };

            if (!TryValidateModel(product))
            {
                return MyApiHelper.ResponseMessage(HttpStatusCode.BadRequest, new ResponseObject { Message = "Validation Failed", Data =  new ValidationResultModel(ModelState)}, HttpContext);
            }
            var images = await _imageUploadHelper.ImageUpload(Files);
            product.Thumbnail = images;
            ServiceResponse serResp = await _productService.InsertProduct(product);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            if (int.TryParse(id, out int categoryId))
            {
                if (_productService.IsExist(categoryId, out _))
                {
                    ServiceResponse serResp = await _productService.DeleteProduct(categoryId);
                    return MyApiHelper.RequestResultParser(serResp, HttpContext);
                }
                return MyApiHelper.ResponseMessage(HttpStatusCode.NotFound, new ResponseObject { Message = "Product Not Found" }, HttpContext);
            }
            return MyApiHelper.ValidationFailedResponseMessage("Id", id, "Invalid param", HttpContext);
        }
    }
}
