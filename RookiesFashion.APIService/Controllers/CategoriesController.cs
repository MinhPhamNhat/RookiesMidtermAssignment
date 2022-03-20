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
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.APIService.Models.DTO;
using AutoMapper;

namespace RookiesFashion.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly RookiesFashionContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(RookiesFashionContext context, ICategoryService categoryService, ICloudinaryService cloudinaryService, IMapper mapper)
        {
            _context = context;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            ServiceResponse serResp = await _categoryService.GetCategories();
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // GET: api/Categories/filter?abc=123
        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult> GetCategoriesFilter([FromQuery] CategoryBaseQueryCriteriaDto baseQuery, CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonConvert.SerializeObject(baseQuery));
            ServiceResponse serResp = await _categoryService.GetPagedCategoryFilter(baseQuery, cancellationToken);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // GET: api/Categories/filter?abc=123
        [HttpGet]
        [Route("parents")]
        public async Task<ActionResult> GetParentCategories()
        {
            
            ServiceResponse serResp = await _categoryService.GetParentCategories();
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            ServiceResponse serResp = await _categoryService.GetCategoryById(id);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, CategoryFormDTO categoryDto)
        {
            if (id == categoryDto.CategoryId)
            {
                if (_categoryService.IsExist(id))
                {
                    var category = _mapper.Map<Category>(categoryDto);
                    ServiceResponse serResp = await _categoryService.UpdateCategory(category);
                    return MyApiHelper.RequestResultParser(serResp, HttpContext);
                }
                return MyApiHelper.ResponseMessage(
                    HttpStatusCode.NotFound,
                    new ResponseObject { Message = "Category Not Found" },
                    HttpContext
                );
            }
            return MyApiHelper.ValidationFailedResponseMessage("Id", id, "Invalid param", HttpContext);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCategory(CategoryFormDTO categoryDto)
        {   
            var category = _mapper.Map<Category>(categoryDto);
            ServiceResponse serResp = await _categoryService.InsertCategory(category);
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (_categoryService.IsExist(id))
            {
                ServiceResponse serResp = await _categoryService.DeleteCategory(id);
                return MyApiHelper.RequestResultParser(serResp, HttpContext);
            }
            return MyApiHelper.ResponseMessage(
                HttpStatusCode.NotFound,
                new ResponseObject { Message = "Category Not Found" },
                HttpContext
            );
        }
    }
}
