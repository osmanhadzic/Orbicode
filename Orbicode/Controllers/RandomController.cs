using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orbicode.Data;

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

        public async Task<IActionResult> Find()
        {
            // get numbers off rows in table food
            var count = _context.foods.Count();
            ViewData["Random"] = count;
            return View();
        }
    }
}
