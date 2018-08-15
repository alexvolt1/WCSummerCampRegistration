using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCSummerCampRegistration.Data;
using WCSummerCampRegistration.Models;

namespace WCSummerCampRegistration.Controllers
{
    public class CampersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campers.ToListAsync());
        }

        // GET: Campers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // GET: Campers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Birthdate,Street,City,State,Zip,Email,Phone,ParentName")] Camper camper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camper);
        }

        // GET: Campers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers.FindAsync(id);
            if (camper == null)
            {
                return NotFound();
            }
            return View(camper);
        }

        // POST: Campers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Birthdate,Street,City,State,Zip,Email,Phone,ParentName")] Camper camper)
        {
            if (id != camper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamperExists(camper.Id))
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
            return View(camper);
        }

        // GET: Campers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // POST: Campers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camper = await _context.Campers.FindAsync(id);
            _context.Campers.Remove(camper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamperExists(int id)
        {
            return _context.Campers.Any(e => e.Id == id);
        }
    }
}
