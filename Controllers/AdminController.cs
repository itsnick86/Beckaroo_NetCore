using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beckaroo_NetCore.Data;
using Beckaroo_NetCore.Models;
namespace Beckaroo_NetCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly Beckaroo_NetCoreContext _context;
        private readonly ILogger<AdminController> _logger;

        public AdminController(
            Beckaroo_NetCoreContext context
            , ILogger<AdminController> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn([Bind("Username, Password")] Admin admin)
        {
            //Check if Username or Password isn't provided
            if(admin.Username == null || admin.Password == null) 
            {
                return View("Index");
            }

            //Find User in Database
            var user = _context.Admin
                .FirstOrDefault(m => m.Username == admin.Username);

            //Check if user is empty
            if (user == null)
            {
                return View("Index");
            }

            //Validate Username and Password provided
            if (user.Username == admin.Username && user.Password == admin.Password)
            {
                return RedirectToAction("Index", "Blogs");
            }
            else
            {
                return View("Index");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
