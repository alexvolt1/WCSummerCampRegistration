using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSummerCampRegistration.Data;
using WCSummerCampRegistration.Models;
using WCSummerCampRegistration.Models.AvailWeekViewModels;

namespace WCSummerCampRegistration.Controllers
{
    public class AvailWeeksController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public AvailWeekViewModel AvailWeekVM { get; set; }

        public AvailWeeksController(ApplicationDbContext context)
        {
            _context = context;
            AvailWeekVM = new AvailWeekViewModel()
            {
                Category = _context.Categories.ToList(),
                AvailWeek = new Models.AvailWeek()
            };
        }

        // GET: AvailWeeks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AvailWeeks.Include(a => a.Camp).Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AvailWeeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availWeek = await _context.AvailWeeks
                .Include(a => a.Camp)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availWeek == null)
            {
                return NotFound();
            }

            return View(availWeek);
        }

        // GET: AvailWeeks/Create
        public IActionResult Create()
        {
            //ViewData["CampId"] = new SelectList(_context.Camps, "Id", "Name");
           // ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");

            return View(AvailWeekVM);
        }

        // POST: AvailWeeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            AvailWeekVM.AvailWeek.CampId = Convert.ToInt32(Request.Form["CampId"].ToString());
            if (!ModelState.IsValid)
            {

                return View(AvailWeekVM);
            }
            //for (int i=0; i<5;i++) {
                //AvailWeekVM.AvailWeek.Id = 8 + i;
                //_context.Entry(AvailWeekVM.AvailWeek).State = EntityState.Added;
                _context.AvailWeeks.Add(AvailWeekVM.AvailWeek);
            //}
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetCamps(int CategoryId)
        {
            List<Camp> campList = new List<Camp>();

            campList = (from camp in _context.Camps
                               where camp.CategoryId == CategoryId
                               select camp).ToList();

            return Json(new SelectList(campList, "Id", "Name"));
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

        // GET: AvailWeeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availWeek = await _context.AvailWeeks.FindAsync(id);
            if (availWeek == null)
            {
                return NotFound();
            }
            ViewData["CampId"] = new SelectList(_context.Camps, "Id", "Name", availWeek.CampId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", availWeek.CategoryId);
            return View(availWeek);
        }

        // POST: AvailWeeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,CampId")] AvailWeek availWeek)
        {
            if (id != availWeek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availWeek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailWeekExists(availWeek.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampId"] = new SelectList(_context.Camps, "Id", "Name", availWeek.CampId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", availWeek.CategoryId);
            return View(availWeek);
        }

        // GET: AvailWeeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availWeek = await _context.AvailWeeks
                .Include(a => a.Camp)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availWeek == null)
            {
                return NotFound();
            }

            return View(availWeek);
        }

        // POST: AvailWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availWeek = await _context.AvailWeeks.FindAsync(id);
            _context.AvailWeeks.Remove(availWeek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailWeekExists(int id)
        {
            return _context.AvailWeeks.Any(e => e.Id == id);
        }
    }
}
