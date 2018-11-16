using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        }
        public async Task<IActionResult> Index()
        {

            IndexVM = new IndexViewModel()
            {
                AvailWeek = await _context.AvailWeeks.Include(m => m.Category).Include(m => m.Camp).ToListAsync(),
                Category = _context.Categories.OrderBy(c => c.Id),
                Camp = _context.Camps.Where(c => c.IsAvailable).ToList()

            };

            IndexVM.AvailWeeksDict = new Dictionary<int, string>();
            foreach (var aweek in IndexVM.AvailWeek)
            {
                IndexVM.AvailWeeksDict.Add(aweek.Id, aweek.Name);
            }
            return View(IndexVM);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var AvailWeekFromDb = await _context.AvailWeeks.Include(m => m.Category).Include(m => m.Camp).Where(m => m.Id == id).FirstOrDefaultAsync();

            ShoppingCart CartObj = new ShoppingCart()
            {
                AvailWeek = AvailWeekFromDb,
                AvailWeekId = AvailWeekFromDb.Id
            };

            return View(CartObj);

        }
        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Details(ShoppingCart CartObject)
        //{
        //    CartObject.Id = 0;
        //    if (ModelState.IsValid)
        //    {
        //        var claimsIdentity = (ClaimsIdentity)this.User.Identity;
        //        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //        CartObject.ApplicationUserId = claim.Value;

        //        ShoppingCart cartFromDb = await _context.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId
        //                                            && c.AvailWeekId == CartObject.AvailWeekId).FirstOrDefaultAsync();

        //        if (cartFromDb == null)
        //        {
        //            //this menu item does not exists
        //            for (int i = 0; i < 5; i++)
        //            {
        //                ShoppingCart CartObject2 = new ShoppingCart();
        //                CartObject2.AvailWeekId = i;
        //                CartObject2.ApplicationUserId = claim.Value;
        //                _context.ShoppingCart.Add(CartObject2);
        //                _context.SaveChanges();
        //            }








        //        }
        //        else
        //        {
        //            //menu item exists in shopping cart for that user, so just update the count
        //            cartFromDb.Count= cartFromDb.Count + CartObject.Count;
        //        }

        //       // await _context.SaveChangesAsync();

        //        var count = _context.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId).ToList().Count();
        //        HttpContext.Session.SetInt32("CartCount", count);

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        var AvailWeekFromDb = await _context.AvailWeeks.Include(m => m.Category).Include(m => m.Camp).Where(m => m.Id == CartObject.AvailWeekId).FirstOrDefaultAsync();

        //        ShoppingCart CartObj = new ShoppingCart()
        //        {
        //            AvailWeek = AvailWeekFromDb,
        //            AvailWeekId = AvailWeekFromDb.Id
        //        };

        //        return View(CartObj);
        //    }
        //}



        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ShoppingCart CartObject)
        {
            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObject.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = await _context.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId
                                                    && c.AvailWeekId == CartObject.AvailWeekId).FirstOrDefaultAsync();

                if (cartFromDb == null)
                {
                    //this menu item does not exists
                    for (int i = 0; i < 5; i++)
                    {
                        ShoppingCart CartObject2 = new ShoppingCart();
                        CartObject2.AvailWeekId = i;
                        CartObject2.ApplicationUserId = claim.Value;
                        _context.ShoppingCart.Add(CartObject2);
                        _context.SaveChanges();
                    }



                }
                else
                {
                    //menu item exists in shopping cart for that user, so just update the count
                    cartFromDb.Count = cartFromDb.Count + CartObject.Count;
                }

                // await _context.SaveChangesAsync();

                var count = _context.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId).ToList().Count();
                HttpContext.Session.SetInt32("CartCount", count);

                return RedirectToAction("Index");
            }
            else
            {
                var AvailWeekFromDb = await _context.AvailWeeks.Include(m => m.Category).Include(m => m.Camp).Where(m => m.Id == CartObject.AvailWeekId).FirstOrDefaultAsync();

                ShoppingCart CartObj = new ShoppingCart()
                {
                    AvailWeek = AvailWeekFromDb,
                    AvailWeekId = AvailWeekFromDb.Id
                };

                return View(CartObj);
            }
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





        public async Task<JsonResult> DoesWeekCampCatExistAsync(string name, int categoryId, int campId)
        {

            var week = await _context.AvailWeeks
                .Include(c => c.Category)
                .Where(a => a.CategoryId == categoryId)
                .Where(b => b.CampId == campId)
                .FirstOrDefaultAsync(m => m.Name == name);

            return Json(week == null);

        }

        public async Task<IActionResult> Details2(int camperId, int categoryId, int campId, int availWeekId)
        {


            ShoppingCart CartObject = new ShoppingCart();

            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObject.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = await _context.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId
                                                    && c.AvailWeekId == CartObject.AvailWeekId).FirstOrDefaultAsync();

                if (cartFromDb == null)
                {
                    //this menu item does not exists
                   // for (int i = 0; i < 5; i++)
                   //{
                        
                        CartObject.CamperId = camperId;
                    CartObject.CategoryId = categoryId;
                    CartObject.CampId = campId;
                    CartObject.AvailWeekId = availWeekId;
                    CartObject.ApplicationUserId = claim.Value;
                        _context.ShoppingCart.Add(CartObject);
                        _context.SaveChanges();
                    //}



                }
                else
                {
                    //menu item exists in shopping cart for that user, so just update the count
                    cartFromDb.Count = cartFromDb.Count + CartObject.Count;
                }

                // await _context.SaveChangesAsync();

                var count = _context.ShoppingCart.Where(c => c.ApplicationUserId == CartObject.ApplicationUserId).ToList().Count();
                HttpContext.Session.SetInt32("CartCount", count);

                return RedirectToAction("Index");
            }
            else
            {
                var AvailWeekFromDb = await _context.AvailWeeks.Include(m => m.Category).Include(m => m.Camp).Where(m => m.Id == CartObject.AvailWeekId).FirstOrDefaultAsync();

                ShoppingCart CartObj = new ShoppingCart()
                {
                    AvailWeek = AvailWeekFromDb,
                    AvailWeekId = AvailWeekFromDb.Id
                };

                return View(CartObj);
            }


        }

    }
}
