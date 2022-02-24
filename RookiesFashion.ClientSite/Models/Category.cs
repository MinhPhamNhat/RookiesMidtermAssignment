using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RookiesFashion.ClientSite.Models;


public class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    public bool IsParent { get; set; } = false;

    public int? ParentCategoryId { get; set; }
    public Category? Parent { get; set; }

    public IEnumerable<Category>? Children { get; set; }

    public IEnumerable<Product>? Products { get; set; }
}