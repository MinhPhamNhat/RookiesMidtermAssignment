using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels;
public class ProductVM
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int? CategoryId { get; set; }
    public CategoryVM? Category { get; set; }
    public IEnumerable<ImageVM>? Thumbnail { get; set; }
    public List<RatingVM>? Ratings { get; set; }
    public double AvgRating { get; set; }
    public IEnumerable<ColorVM>? Colors { get; set; }
    public IEnumerable<SizeVM>? Sizes { get; set; }

    
}