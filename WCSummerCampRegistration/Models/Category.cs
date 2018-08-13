using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Column(TypeName = "nvarchar(32)")]
        [Remote("doesCategoryExistAsync", "Categories", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string Name { get; set; }

    }
}
