using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Beckaroo_NetCore.Data;
using Beckaroo_NetCore.Models;

namespace Beckaroo_NetCore.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly Beckaroo_NetCoreContext _context;

        public AnimalsController(Beckaroo_NetCoreContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animal.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .FirstOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/CreateAnimal
        public IActionResult CreateAnimal()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnimal([Bind("AnimalID,Name,Description,ImageMain,ImageMainFile,ImageSecondary,ImageSecondaryFile")] Animal animal, string animalDescription)
        {
            if (ModelState.IsValid)
            {
                animal.Description = animalDescription.ToString();

                //Save Main Image (Picture displayed on the Zoo page)
                if (animal.ImageMainFile != null && animal.ImageMainFile.Length > 0)
                {
                    var fileName = Path.GetFileName(animal.ImageMainFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await animal.ImageMainFile.CopyToAsync(fileSteam);
                    }
                    animal.ImageMain = fileName;
                }

                //Save Secondary Image (Modal Picture)
                if (animal.ImageSecondaryFile != null && animal.ImageSecondaryFile.Length > 0)
                {
                    var fileName = Path.GetFileName(animal.ImageSecondaryFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await animal.ImageSecondaryFile.CopyToAsync(fileSteam);
                    }
                    animal.ImageSecondary = fileName;
                }

                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalID,Name,Description,ImageMain,ImageSecondary")] Animal animal)
        {
            if (id != animal.AnimalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalID))
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
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .FirstOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.AnimalID == id);
        }
    }
}
