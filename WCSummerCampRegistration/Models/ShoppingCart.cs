using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int CamperId { get; set; }
        public int CategoryId { get; set; }
        public int CampId { get; set; }
        public int AvailWeekId { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        [ForeignKey("CamperId")]
        public virtual Camper Camper { get; set; }

        [NotMapped]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [NotMapped]
        [ForeignKey("CampId")]
        public virtual Camp Camp { get; set; }

        [NotMapped]
        [ForeignKey("AvailWeekId")]
        public virtual AvailWeek AvailWeek { get; set; }

        [NotMapped]
        public string StatusMessage { get; set; }

    }
}
