using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orbicode.Data;
using Orbicode.Models;

namespace Orbicode.Controllers
{
    public class FoodsController : Controller
    {
        private readonly RestoranContext _context;

        public FoodsController(RestoranContext context)
        {
            _context = context;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            return View(await _context.foods.ToListAsync());
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.foods
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,naziv,cijena,MyProperty,restoran")] Food food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(food);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (DbUpdateException)
            {

                ModelState.AddModelError("","Pokusajte kasnije");
            }
            
            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodToUpdate = await _context.foods.FirstOrDefaultAsync(f => f.id == id);
            if(await TryUpdateModelAsync<Food>(
                foodToUpdate,
                "",
                f => f.naziv, f => f.cijena, f => f.MyProperty))
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Pokusajte kasnije");
                }

            return View(foodToUpdate);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.foods
                .FirstOrDefaultAsync(m => m.id == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await _context.foods.FindAsync(id);
            if (food == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.foods.Remove(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });

            }
            
        }

        private bool FoodExists(int id)
        {
            return _context.foods.Any(e => e.id == id);
        }
    }
}
