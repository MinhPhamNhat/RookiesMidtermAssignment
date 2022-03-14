
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Category? Category { get; set; }
        public List<Rating>? Ratings { get; set; }
        public double AvgRating { get => Math.Round(Ratings.Aggregate<Rating, double>(0, (x, y) => x + ((double)y.RatingVal / Ratings.Count())), 1); }
        public IEnumerable<UpdatedDate>? UpdatedDates { get; set; }
        public IEnumerable<ImageDTO>? Thumbnail { get; set; }
        public IEnumerable<Color>? Colors { get; set; }
        public IEnumerable<Size>? Sizes { get; set; }
    }
}