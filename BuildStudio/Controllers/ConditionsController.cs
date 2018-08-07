using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildStudio.Data;
using BuildStudio.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BuildStudio.Controllers
{
    public class ConditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: conditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condition = await _context
                                    .Conditions
                                    .Include(cn => cn.AcceptanceCriteria)
                                    .Include(cn => cn.ExpectedResults)
                                    .SingleOrDefaultAsync(cn => cn.Id == id);

            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // GET: conditions/Create/1
        public IActionResult Create(int? id)
        {
            var condition = new Condition
            {
                AcceptanceCriteriaId = id.GetValueOrDefault()
            };

            ViewData["AcceptanceCriteriaId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", condition.AcceptanceCriteriaId);

            return View(condition);
        }

        // POST: conditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Condition.BindableProperties)] Condition condition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condition);

                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "AcceptanceCriterias", new { Id = condition.AcceptanceCriteriaId });
            }

            ViewData["AcceptanceCriteriaId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", condition.AcceptanceCriteriaId);

            return View(condition);
        }

        // GET: conditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condition = await _context
                                    .Conditions
                                    .SingleOrDefaultAsync(cn => cn.Id == id);

            if (condition == null)
            {
                return NotFound();
            }

            ViewData["AcceptanceCriteriaId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", condition.AcceptanceCriteriaId);

            return View(condition);
        }

        // POST: conditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(Condition.BindablePropertiesForEdition)] Condition condition)
        {
            if (id != condition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condition);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionExists(condition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "AcceptanceCriterias", new { Id = condition.AcceptanceCriteriaId });
            }

            ViewData["AcceptanceCriteriaId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", condition.AcceptanceCriteriaId);

            return View(condition);
        }

        // GET: conditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condition = await _context
                                    .Conditions
                                    .Include(cn => cn.AcceptanceCriteria)
                                    .SingleOrDefaultAsync(cn => cn.Id == id);

            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // POST: conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condition = await _context
                                    .Conditions
                                    .SingleOrDefaultAsync(cn => cn.Id == id);

            _context.Conditions.Remove(condition);

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "AcceptanceCriterias", new { Id = condition.AcceptanceCriteriaId });
        }

        private bool ConditionExists(int id)
        {
            return _context.Conditions.Any(e => e.Id == id);
        }
    }
}