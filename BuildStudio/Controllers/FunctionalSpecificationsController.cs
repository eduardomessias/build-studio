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

namespace BuildStudio.Controllers
{
    [Authorize]
    public class FunctionalSpecificationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public FunctionalSpecificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FunctionalSpecifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.FunctionalSpecifications.ToListAsync());
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
                                                .Include(spec => spec.Functionalities)
                                                .SingleOrDefaultAsync(m => m.Id == id);

            if (functionalSpecification == null)
            {
                return NotFound();
            }

            return View(functionalSpecification);
        }

        // GET: FunctionalSpecifications/Create
        public IActionResult Create()
        {
            return View(new FunctionalSpecification());
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

            var functionalSpecification = await _context.FunctionalSpecifications.SingleOrDefaultAsync(m => m.Id == id);
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
                .SingleOrDefaultAsync(m => m.Id == id);
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
            var functionalSpecification = await _context.FunctionalSpecifications.SingleOrDefaultAsync(m => m.Id == id);
            _context.FunctionalSpecifications.Remove(functionalSpecification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctionalSpecificationExists(int id)
        {
            return _context.FunctionalSpecifications.Any(e => e.Id == id);
        }
    }
}
