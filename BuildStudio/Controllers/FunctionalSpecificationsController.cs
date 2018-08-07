using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildStudio.Data;
using BuildStudio.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BuildStudio.Models;

namespace BuildStudio.Controllers
{
    [Authorize]
    public class FunctionalSpecificationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public FunctionalSpecificationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FunctionalSpecifications
        public async Task<IActionResult> Index(string author)
        {
            var functionalSpecifications = String.IsNullOrEmpty(author) ?
                                                await _context.FunctionalSpecifications.ToListAsync() :
                                                await _context.FunctionalSpecifications.Where(fs => fs.Author == author).ToListAsync();

            return View(functionalSpecifications);
        }

        // GET: FunctionalSpecifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionalSpecification = await _context
                                                .FunctionalSpecifications
                                                .Include(fs => fs.Functionalities)
                                                .SingleOrDefaultAsync(fs => fs.Id == id);

            if (functionalSpecification == null)
            {
                return NotFound();
            }

            return View(functionalSpecification);
        }

        // GET: FunctionalSpecifications/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            var functionalSpecification = new FunctionalSpecification
            {
                Author = user?.FullName
            };

            return View(functionalSpecification);
        }

        // POST: FunctionalSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(FunctionalSpecification.BindableProperties)] FunctionalSpecification functionalSpecification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functionalSpecification);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(functionalSpecification);
        }

        // GET: FunctionalSpecifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionalSpecification = await _context.FunctionalSpecifications.SingleOrDefaultAsync(fs => fs.Id == id);
            if (functionalSpecification == null)
            {
                return NotFound();
            }
            functionalSpecification.Version = functionalSpecification.Version.Incremented();
            return View(functionalSpecification);
        }

        // POST: FunctionalSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(FunctionalSpecification.BindableProperties)] FunctionalSpecification functionalSpecification)
        {
            if (id != functionalSpecification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(functionalSpecification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctionalSpecificationExists(functionalSpecification.Id))
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
            return View(functionalSpecification);
        }

        // GET: FunctionalSpecifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionalSpecification = await _context.FunctionalSpecifications
                .SingleOrDefaultAsync(fs => fs.Id == id);
            if (functionalSpecification == null)
            {
                return NotFound();
            }

            return View(functionalSpecification);
        }

        // POST: FunctionalSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var functionalSpecification = await _context.FunctionalSpecifications.SingleOrDefaultAsync(fs => fs.Id == id);
            _context.FunctionalSpecifications.Remove(functionalSpecification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctionalSpecificationExists(int id)
        {
            return _context.FunctionalSpecifications.Any(fs => fs.Id == id);
        }
    }
}
