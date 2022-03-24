#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly RookiesFashionContext _context;
        private readonly IRatingService _ratingService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public RatingsController(RookiesFashionContext context, IRatingService ratingService, IProductService productService, IMapper mapper)
        {
            _ratingService = ratingService;
            _productService = productService;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Colors
        [HttpGet("{productId}")]
        public async Task<ActionResult> GetRatings(int productId, [FromQuery] RatingBaseQueryCriteriaDto baseQueryCriteria, CancellationToken cancellationToken)
        {
            if (_productService.IsExist(productId, out _))
            {
                ServiceResponse serResp = await _ratingService.GetPagingRating(productId, baseQueryCriteria, cancellationToken);
                return MyApiHelper.RequestResultParser(serResp, HttpContext);
            }
            return MyApiHelper.ResponseMessage(
                HttpStatusCode.NotFound,
                new ResponseObject { Message = "Product Not Found" },
                HttpContext
            );

        }


        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult> InsertRating([FromForm] RatingFormDTO ratingFormDTO)
        {
            // Console.WriteLine(JsonConvert.SerializeObject(ratingFormDTO));
            if (_productService.IsExist(ratingFormDTO.ProductId, out _))
            {
                var rating = _mapper.Map<Rating>(ratingFormDTO);
                rating.UserRating = User.Claims.Where(c => c.Type.Equals("name")).First().Value;
                ServiceResponse serResp = await _ratingService.InsertRating(rating);
                return MyApiHelper.RequestResultParser(serResp, HttpContext);
            }
            return MyApiHelper.ResponseMessage(
                HttpStatusCode.NotFound,
                new ResponseObject { Message = "Product Not Found" },
                HttpContext
            );
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var color = await _context.Colors.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorExists(int id)
        {
            return _context.Colors.Any(e => e.ColorId == id);
        }
    }
}
