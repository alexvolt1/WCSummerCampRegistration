﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class AvailableWeek
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Week Start")]
        [Column(TypeName = "nvarchar(16)")]
        public string WeekStart { get; set; }

        public enum EWeekStarts
        {
            [Display(Name = "6/10")]
            Week1 = 1,
            [Display(Name = "6/17")]
            Week2 = 2,
            [Display(Name = "6/24")]
            Week3 = 3,
            [Display(Name = "7/1")]
            Week4 = 4,
            [Display(Name = "7/8")]
            Week5 = 5,
            [Display(Name = "7/15")]
            Week6 = 6,
            [Display(Name = "7/22")]
            Week7 = 7,
            [Display(Name = "7/29")]
            Week8 = 8,
            [Display(Name = "8/5")]
            Week9 = 9,
            [Display(Name = "8/12")]
            Week10 = 10,
            [Display(Name = "8/19")]
            Week11 = 11,
            [Display(Name = "8/26")]
            Week12 = 2,
        };

        [Required]
        [Display(Name = "Academy Camp")]
        public int AcademyCampId { get; set; }

        [ForeignKey("AcademyCampId")]
        public virtual AcademyCamp AcademyCamp { get; set; }
    }
}
