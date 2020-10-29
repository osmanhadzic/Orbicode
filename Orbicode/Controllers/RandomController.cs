using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orbicode.Data;
using Orbicode.Models;

namespace Orbicode.Controllers
{
    public class RandomController : Controller
    {
        private readonly RestoranContext _context;

        public RandomController(RestoranContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            int? id;
            id = randomNumberGenerator();
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.foods.FindAsync(id);
            
            if (food == null)
            {
                return NotFound();
            }
           var restId = food.restoranId;
           var rest = await _context.restorans.FindAsync(restId);
           ViewBag.Restoran = rest.naziv;
            return View(food);
        }
        private int randomNumberGenerator()
        {
            return 6;
        }
    }
}
