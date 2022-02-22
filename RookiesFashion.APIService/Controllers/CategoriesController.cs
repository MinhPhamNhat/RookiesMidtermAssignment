#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookiesFashion.APIService.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services;

namespace RookiesFashion.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RookiesFashionContext _context;
        private readonly ICategoryService _categoryService;
        private readonly ICloudinaryService _cloudinaryService;

        private MyApiHelper apiHelper;
        public CategoriesController(RookiesFashionContext context, ICategoryService categoryService, ICloudinaryService cloudinaryService)
        {
            _context = context;
            _categoryService = categoryService;
            _cloudinaryService = cloudinaryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            apiHelper = new MyApiHelper(HttpContext);
            ServiceResponse serResp = await _categoryService.GetCategories();
            return apiHelper.GetRequestServiceResult(serResp);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(string id)
        {
            apiHelper = new MyApiHelper(HttpContext);
            if (int.TryParse(id, out int categoryId))
            {
                ServiceResponse serResp = await _categoryService.GetCategoryById(categoryId);
                return apiHelper.GetRequestServiceResult(serResp);
            }
            return apiHelper.ValidationResponseMessage("Id", id, "Invalid param");
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(string id, [FromForm] Category category)
        {
            apiHelper = new MyApiHelper(HttpContext);
            if (int.TryParse(id, out int categoryId) && categoryId == category.CategoryId)
            {
                if (_categoryService.IsExist(categoryId))
                {
                    ServiceResponse serResp = await _categoryService.UpdateCategory(category);
                    return apiHelper.GetRequestServiceResult(serResp);
                }
                return apiHelper.ResponseMessage(HttpStatusCode.NotFound, "Category Not Found");
            }
            return apiHelper.ValidationResponseMessage("Id", id, "Invalid param");
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCategory([FromForm] Category category)
        {
            apiHelper = new MyApiHelper(HttpContext);
            ServiceResponse serResp = await _categoryService.InsertCategory(category);
            return apiHelper.GetRequestServiceResult(serResp);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            apiHelper = new MyApiHelper(HttpContext);
            if (int.TryParse(id, out int categoryId))
            {
                if (_categoryService.IsExist(categoryId))
                {
                    ServiceResponse serResp = await _categoryService.DeleteCategory(categoryId);
                    return apiHelper.GetRequestServiceResult(serResp);
                }
                return apiHelper.ResponseMessage(HttpStatusCode.NotFound, "Category Not Found");
            }
            return apiHelper.ValidationResponseMessage("Id", id, "Invalid param");
        }
    }
}
