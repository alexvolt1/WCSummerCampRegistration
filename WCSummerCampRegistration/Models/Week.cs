using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class Week
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Week Start")]
        [Column(TypeName = "nvarchar(16)")]
        public string WeekStart { get; set; }

        [Required]
        [Display(Name = "Camp")]
        public int CampId { get; set; }

        [ForeignKey("CampId")]
        public virtual AcademyCamp Camp { get; set; }
    }
}
