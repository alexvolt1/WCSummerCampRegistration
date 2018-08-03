﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class AcademyCamp
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Academy Camp Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Column(TypeName = "nvarchar(32)")]
        public string CampName { get; set; }

        [Required]
        [Display(Name = "Age From")]
        public int AgeFrom { get; set; }

        [Required]
        [Display(Name = "Age To")]
        public int AgeTo { get; set; }

        //[Required]
        //[Display(Name = "Stand Alone Camp Member Price")]
        //[Column(TypeName = "decimal(10, 2)")]
        //public decimal MembPriceNoDayCamp { get; set; }

        //[Required]
        //[Display(Name = "Stand Alone Camp Non Member Price")]
        //[Column(TypeName = "decimal(10, 2)")]
        //public decimal NonMembPriceNoDayCamp { get; set; }
        //[Required]
        //[Display(Name = "W/Day Camp Member Price")]
        //[Column(TypeName = "decimal(10, 2)")]
        //public decimal MembPriceWithDayCamp { get; set; }

        //[Required]
        //[Display(Name = "W/Day Camp Non Member Price")]
        //[Column(TypeName = "decimal(10, 2)")]
        //public decimal NonMembPriceWithDayCamp { get; set; }
    }
}
