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

        // GET: Blogs
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

        public IActionResult BlogGet()
        {
            return View("Blog");
        }
    }
}
