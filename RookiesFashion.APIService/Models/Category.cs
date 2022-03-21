using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RookiesFashion.APIService.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public bool IsDeleted { get; set; } = false;
        public string? Description { get; set; }
        public bool IsParent { get; set; } = true;

        public int? ParentCategoryId { get; set; }
        public virtual Category? Parent { get; set; }
        public virtual IEnumerable<Category>? Children { get; set; }
        public virtual IEnumerable<Product>? Products { get; set; }
    }
}
