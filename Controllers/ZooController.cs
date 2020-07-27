using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beckaroo_NetCore.Models;
using Beckaroo_NetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Beckaroo_NetCore.Controllers
{
    public class ZooController : Controller
    {
        private readonly Beckaroo_NetCoreContext _context;

        public ZooController(Beckaroo_NetCoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Animal.ToListAsync());
        }

        public async Task<IActionResult> AnimalDetail(int? animalID)
        {
            if (animalID == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(animalID);
            if (animal == null)
            {
                return NotFound();
            }
            return View("_AnimalDetail", animal);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
