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

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IndexViewModel IndexVM = new IndexViewModel()
            {
                AvailWeek = await _context.AvailWeeks.Include(m => m.Category).Include(m => m.Camp).ToListAsync(),
                Category = _context.Categories.OrderBy(c => c.Id),
                Camp = _context.Camps.Where(c => c.IsAvailable).ToList()
                
            };
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
