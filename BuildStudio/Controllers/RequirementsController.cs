using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildStudio.Data;
using BuildStudio.Data.Model;

namespace BuildStudio.Controllers
{
    public class RequirementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requirements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _context
                                    .Requirements
                                    .Include(r => r.Functionality)
                                    .SingleOrDefaultAsync(m => m.Id == id);

            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        // GET: Requirements/Create/1
        public IActionResult Create(int? id)
        {
            var requirement = new Requirement
            {
                FunctionalityId = id.GetValueOrDefault()
            };

            ViewData["FunctionalityId"] = new SelectList(_context.Functionalities, "Id", "Name", requirement.FunctionalityId);

            return View(requirement);
        }

        // POST: Requirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Requirement.BindableProperties)] Requirement requirement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requirement);

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Functionalities", new { Id = requirement.FunctionalityId });
            }

            ViewData["FunctionalityId"] = new SelectList(_context.Functionalities, "Id", "Name", requirement.FunctionalityId);

            return View(requirement);
        }

        // GET: Requirements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _context.Requirements.SingleOrDefaultAsync(m => m.Id == id);

            if (requirement == null)
            {
                return NotFound();
            }

            ViewData["FunctionalityId"] = new SelectList(_context.Functionalities, "Id", "Name", requirement.FunctionalityId);

            return View(requirement);
        }

        // POST: Requirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(Requirement.BindablePropertiesForEdition)] Requirement requirement)
        {
            if (id != requirement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requirement);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequirementExists(requirement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Functionalities", new { Id = requirement.FunctionalityId });
            }
            ViewData["FunctionalityId"] = new SelectList(_context.Functionalities, "Id", "Name", requirement.FunctionalityId);
            return View(requirement);
        }

        // GET: Requirements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _context
                                    .Requirements
                                    .Include(r => r.Functionality)
                                    .SingleOrDefaultAsync(m => m.Id == id);

            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        // POST: Requirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requirement = await _context
                                    .Requirements
                                    .SingleOrDefaultAsync(m => m.Id == id);

            _context.Requirements.Remove(requirement);

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Functionalities", new { Id = requirement.FunctionalityId });
        }

        private bool RequirementExists(int id)
        {
            return _context.Requirements.Any(e => e.Id == id);
        }
    }
}
