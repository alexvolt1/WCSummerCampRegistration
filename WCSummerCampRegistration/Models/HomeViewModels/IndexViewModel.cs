using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Camp> Camp { get; set; }
        public IEnumerable<AvailWeek> AvailWeek { get; set; }
        public Dictionary<int, string> AvailWeeksDict { get; set; }
    }
}
