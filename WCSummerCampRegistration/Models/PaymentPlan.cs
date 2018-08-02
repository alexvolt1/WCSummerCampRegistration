using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class PaymentPlan
    {
        [Required]
        public int Id { get; set; }


        [Display(Name = "Payment Month")]
        [Column(TypeName = "nvarchar(16)")]
        public string Monthly { get; set; }

        [Required]
        [Display(Name = "PaymentOption")]
        public int PaymentOptionId { get; set; }

        [ForeignKey("PaymentOptionId")]
        public virtual PaymentOption PaymentOption { get; set; }
    }
}

