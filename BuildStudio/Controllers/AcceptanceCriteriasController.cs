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
    public class AcceptanceCriteriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcceptanceCriteriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcceptanceCriterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acceptanceCriteria = await _context
                                            .AcceptanceCriterias
                                            .Include(ac => ac.Requirement)
                                            .Include(ac => ac.Conditions)
                                            .SingleOrDefaultAsync(ac => ac.Id == id);

            if (acceptanceCriteria == null)
            {
                return NotFound();
            }

            return View(acceptanceCriteria);
        }

        // GET: AcceptanceCriterias/Create
        public IActionResult Create(int? id)
        {
            var acceptanceCriteria = new AcceptanceCriteria
            {
                RequirementId = id.GetValueOrDefault()
            };

            ViewData["RequirementId"] = new SelectList(_context.Requirements, "Id", "Name", acceptanceCriteria.RequirementId);

            return View();
        }

        // POST: AcceptanceCriterias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(AcceptanceCriteria.BindableProperties)] AcceptanceCriteria acceptanceCriteria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acceptanceCriteria);

                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Requirements", new { Id = acceptanceCriteria.RequirementId });
            }

            ViewData["RequirementId"] = new SelectList(_context.Requirements, "Id", "Name", acceptanceCriteria.RequirementId);

            return View(acceptanceCriteria);
        }

        // GET: AcceptanceCriterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acceptanceCriteria = await _context
                                            .AcceptanceCriterias
                                            .SingleOrDefaultAsync(ac => ac.Id == id);

            if (acceptanceCriteria == null)
            {
                return NotFound();
            }

            ViewData["RequirementId"] = new SelectList(_context.Requirements, "Id", "Name", acceptanceCriteria.RequirementId);

            return View(acceptanceCriteria);
        }

        // POST: AcceptanceCriterias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(AcceptanceCriteria.BindablePropertiesForEdition)] AcceptanceCriteria acceptanceCriteria)
        {
            if (id != acceptanceCriteria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acceptanceCriteria);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcceptanceCriteriaExists(acceptanceCriteria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Details", "Requirements", new { Id = acceptanceCriteria.RequirementId });
            }

            ViewData["RequirementId"] = new SelectList(_context.Requirements, "Id", "Name", acceptanceCriteria.RequirementId);

            return View(acceptanceCriteria);
        }

        // GET: AcceptanceCriterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acceptanceCriteria = await _context
                                            .AcceptanceCriterias
                                            .SingleOrDefaultAsync(ac => ac.Id == id);

            if (acceptanceCriteria == null)
            {
                return NotFound();
            }

            return View(acceptanceCriteria);
        }

        // POST: AcceptanceCriterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acceptanceCriteria = await _context
                                            .AcceptanceCriterias
                                            .SingleOrDefaultAsync(ac => ac.Id == id);

            _context.AcceptanceCriterias.Remove(acceptanceCriteria);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Requirements", new { Id = acceptanceCriteria.RequirementId });
        }

        private bool AcceptanceCriteriaExists(int id)
        {
            return _context.AcceptanceCriterias.Any(ac => ac.Id == id);
        }
    }
}
