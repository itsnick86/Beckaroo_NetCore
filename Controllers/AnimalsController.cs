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

        // POST: Animals/CreateAnimal
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnimal([Bind("AnimalID,Name,Description,DateOfBirth,Species,ImageMain,ImageMainAlt,ImageMainFile,ImageSecondary,ImageSecondaryAlt,ImageSecondaryFile")] Animal animal, string animalDescription)
        {
            if (ModelState.IsValid)
            {
                animal.Description = animalDescription.ToString();

                //Save Main Image (Picture displayed on the Zoo page)
                if (animal.ImageMainFile != null && animal.ImageMainFile.Length > 0)
                {
                    var fileName = Path.GetFileName(animal.ImageMainFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/animal", fileName);
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
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/animal", fileName);
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

        // GET: Animals/EditAnimal/5
        public async Task<IActionResult> EditAnimal(int? id)
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

        // POST: Animals/EditAnimal/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnimal(int id, [Bind("AnimalID,Name,Description,DateOfBirth,Species,ImageMain,ImageMainAlt,ImageMainFile,ImageSecondary,ImageSecondaryAlt,ImageSecondaryFile")] Animal animal, string submit, string animalDescription)
        {
            if (submit == "Delete")
            {
                _context.Animal.Remove(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (id != animal.AnimalID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        animal.Description = animalDescription.ToString();

                        //Save Main Image (Picture displayed on the Zoo page)
                        if (animal.ImageMainFile != null && animal.ImageMainFile.Length > 0)
                        {
                            var fileName = Path.GetFileName(animal.ImageMainFile.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/animal", fileName);
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
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/animal", fileName);
                            using (var fileSteam = new FileStream(filePath, FileMode.Create))
                            {
                                await animal.ImageSecondaryFile.CopyToAsync(fileSteam);
                            }
                            animal.ImageSecondary = fileName;
                        }

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
            }
            return View(animal);
        }

        // Checks to see if the given ID is in the database
        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.AnimalID == id);
        }
    }
}
