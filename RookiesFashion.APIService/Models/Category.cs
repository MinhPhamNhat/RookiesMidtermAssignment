﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RookiesFashion.APIService.Models
{
    [Table("Category")]
    public class Category: IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category? Parent { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name)){
                yield return new ValidationResult("Category name cannot be null or empty", new[]{nameof(Name)});
            }
            if (string.IsNullOrEmpty(Description)){
                yield return new ValidationResult("Category description cannot be null or empty", new[]{nameof(Description)});
            }
        }
    }
}
