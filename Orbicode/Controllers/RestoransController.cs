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
    public class RestoransController : Controller
    {
        private readonly RestoranContext _context;

        public RestoransController(RestoranContext context)
        {
            _context = context;
        }

        // GET: Restorans
        public async Task<IActionResult> Index()
        {
            return View(await _context.restorans.ToListAsync());
        }

        // GET: Restorans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restoran = await _context.restorans
                .FirstOrDefaultAsync(m => m.id == id);
            if (restoran == null)
            {
                return NotFound();
            }

            return View(restoran);
        }

        // GET: Restorans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restorans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,naziv,adresa,brojTelefona")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restoran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restoran);
        }

        // GET: Restorans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restoran = await _context.restorans.FindAsync(id);
            if (restoran == null)
            {
                return NotFound();
            }
            return View(restoran);
        }

        // POST: Restorans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var restoranToUpdate = await _context.restorans.FirstOrDefaultAsync(r => r.id == id);

            if (await TryUpdateModelAsync<Restoran>(
               restoranToUpdate,
               "",
               r => r.naziv, r => r.adresa, r => r.brojTelefona))
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Pokusajte kasnije");
                }

            return View(restoranToUpdate);
        }

        // GET: Restorans/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restoran = await _context.restorans
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.id == id);
            if (restoran == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Brisanje nije uspjelo";
            }

            return View(restoran);
        }

        // POST: Restorans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restoran = await _context.restorans.FindAsync(id);
            if (restoran == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.restorans.Remove(restoran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }

        private bool RestoranExists(int id)
        {
            return _context.restorans.Any(e => e.id == id);
        }
    }
}
