using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category? Category { get; set; }
        public List<Rating>? Ratings { get; set; }
        public double? AvgRating { get; set; }
        public IEnumerable<UpdatedDate>? UpdatedDates { get; set; }
        public IEnumerable<Image>? Thumbnail { get; set; }
        public IEnumerable<Color>? Colors { get; set; }
        public IEnumerable<Size>? Sizes { get; set; }
    }
}