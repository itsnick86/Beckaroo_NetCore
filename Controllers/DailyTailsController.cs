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
using System.Globalization;

namespace Beckaroo_NetCore.Controllers
{
    public class DailyTailsController : Controller
    {
        private readonly Beckaroo_NetCoreContext _context;

        public DailyTailsController(Beckaroo_NetCoreContext context)
        {
            _context = context;
        }

        // GET: DailyTails
        public async Task<IActionResult> Index()
        {
            var dailyTailsViewModel = new DailyTailsViewModel();

            dailyTailsViewModel.Blogs = await _context.Blog.ToListAsync();

            dailyTailsViewModel.ViewDate = (from blog in dailyTailsViewModel.Blogs
                                            select blog.PublishDate)
                                                    .Distinct()
                                                    .Reverse()
                                                    .ToList();

            return View(dailyTailsViewModel);
        }

        // GET: DailyTails/Blog/5
        public async Task<IActionResult> Blog(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.BlogID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}
