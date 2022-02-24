using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookiesFashion.ClientSite.Models.ViewModels;

public class CategoryVM
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    public bool IsParent { get; set; }

    public int? ParentCategoryId { get; set; }
    public CategoryVM? Parent { get; set; }

    public IEnumerable<CategoryVM>? Children { get; set; }
}