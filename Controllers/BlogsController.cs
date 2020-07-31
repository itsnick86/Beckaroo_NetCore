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
    public class BlogsController : Controller
    {
        private readonly Beckaroo_NetCoreContext _context;

        public BlogsController(Beckaroo_NetCoreContext context)
        {
            _context = context;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blog.ToListAsync());
        }

        // GET: Blogs/CreateBlog
        public IActionResult CreateBlog()
        {
            return View();
        }

        // POST: Blogs/CreateBlog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlog([Bind("BlogID,Title,Author,PublishDate,Image,ImageAlt,ImageFile,Content")] Blog blog, string blogContent)
        {
            if (ModelState.IsValid)
            {
                blog.Content = blogContent.ToString();

                if (blog.ImageFile != null && blog.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(blog.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await blog.ImageFile.CopyToAsync(fileSteam);
                    }
                    blog.Image = fileName;
                }
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/EditBlog/5
        public async Task<IActionResult> EditBlog(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/EditBlog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(int? id, [Bind("BlogID,Title,Author,PublishDate,Image,ImageAlt,ImageFile,Content")] Blog blog, string submit, string blogContent)
        {
            if (submit == "Delete")
            {
                _context.Blog.Remove(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (id != blog.BlogID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        blog.Content = blogContent.ToString();

                        if (blog.ImageFile != null && blog.ImageFile.Length > 0)
                        {
                            var fileName = Path.GetFileName(blog.ImageFile.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blog", fileName);
                            using (var fileSteam = new FileStream(filePath, FileMode.Create))
                            {
                                await blog.ImageFile.CopyToAsync(fileSteam);
                            }
                            blog.Image = fileName;
                        }
                        _context.Update(blog);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BlogExists(blog.BlogID))
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
            return View(blog);
        }

        // Checks to see if the given ID is in the database
        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.BlogID == id);
        }
    }
}
