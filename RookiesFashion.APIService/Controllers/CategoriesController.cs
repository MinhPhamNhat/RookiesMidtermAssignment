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

        public CategoriesController(RookiesFashionContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            ServiceResponse serResp = await _categoryService.GetCategories();
            return GetRequestServiceResult(serResp);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(string id)
        {
            if (int.TryParse(id, out int categoryId))
            {
                ServiceResponse serResp = await _categoryService.GetCategoriesById(categoryId);
                return GetRequestServiceResult(serResp);
            }
            return ResponseMessage(HttpStatusCode.BadRequest, new ValidationResultModel(new ValidationError("Id", id, "Invalid param")));
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, [FromForm] Category category)
        {
            if (int.TryParse(id, out int categoryId) && categoryId == category.CategoryId)
            {
                if (_categoryService.IsExist(categoryId))
                {
                    ServiceResponse serResp = await _categoryService.UpdateCategory(category);
                    return GetRequestServiceResult(serResp);
                }
                return ResponseMessage(HttpStatusCode.NotFound, "Category Not Found");
            }
            return ResponseMessage(HttpStatusCode.BadRequest, new ValidationResultModel(new ValidationError("Id", id, "Invalid param")));
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCategory([FromForm] Category category)
        {
            ServiceResponse serResp = await _categoryService.InsertCategory(category);
            return GetRequestServiceResult(serResp);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            if (int.TryParse(id, out int categoryId))
            {
                if (_categoryService.IsExist(categoryId))
                {
                    ServiceResponse serResp = await _categoryService.DeleteCategory(categoryId);
                    return GetRequestServiceResult(serResp);
                }
                return ResponseMessage(HttpStatusCode.NotFound, "Category Not Found");
            }
            return ResponseMessage(HttpStatusCode.BadRequest, new ValidationResultModel(new ValidationError("Id", id, "Invalid param")));
        }

        private JsonResult ResponseMessage(HttpStatusCode statusCode, object resultObj)
        {
            HttpContext.Response.StatusCode = (int)statusCode;
            return new JsonResult(resultObj);
        }

        private JsonResult GetRequestServiceResult(ServiceResponse serResp)
        {
            switch (serResp.Code)
            {
                case ServiceResponseStatus.SUCCESS:
                    return ResponseMessage(HttpStatusCode.OK, new { Message = serResp.Message, Data = serResp.Data });
                case ServiceResponseStatus.ERROR:
                    return ResponseMessage(HttpStatusCode.InternalServerError, new { Message = serResp.Message, Data = serResp.Data });
                case ServiceResponseStatus.OBJECT_NOT_FOUND:
                    return ResponseMessage(HttpStatusCode.NotFound, new { Message = serResp.Message, Data = serResp.Data });
                case ServiceResponseStatus.DATA_CREATED:
                    return ResponseMessage(HttpStatusCode.Created, new { Message = serResp.Message, Data = serResp.Data });
                default:
                    return ResponseMessage(HttpStatusCode.BadRequest, new { Message = "Bad request" });
            }
        }
    }
}
