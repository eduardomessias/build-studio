using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuildStudio.Models;
using Microsoft.AspNetCore.Identity;

namespace BuildStudio.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var isSignedIn = _signInManager.IsSignedIn(User);

            if (isSignedIn)
                return RedirectToAction("Index", "Dashboard");

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                user = new ApplicationUser();

            return View(user);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
