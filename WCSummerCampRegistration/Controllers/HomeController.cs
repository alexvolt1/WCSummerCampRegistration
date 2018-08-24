using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WCSummerCampRegistration.Data;
using WCSummerCampRegistration.Models;
using WCSummerCampRegistration.Models.HomeViewModels;

namespace WCSummerCampRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public IndexViewModel IndexVM { get; set; }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            IndexVM = new IndexViewModel()
            {
                AvailWeek = _context.AvailWeeks.Include(m => m.Category).Include(m => m.Camp).ToList(),
                Category = _context.Categories.OrderBy(c => c.Id),
                Camp = _context.Camps.Where(c => c.IsAvailable).ToList()

            };
        }
        public IActionResult Index()
        {


            IndexVM.AvailWeeksDict = new Dictionary<int, string>();


            foreach (var aweek in IndexVM.AvailWeek)
            {
                IndexVM.AvailWeeksDict.Add(aweek.Id, aweek.Name);
            }


            return View(IndexVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
