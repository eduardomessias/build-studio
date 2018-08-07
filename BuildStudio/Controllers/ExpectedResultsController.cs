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
    public class ExpectedResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpectedResultsController(ApplicationDbContext context)
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

            var expectedResult = await _context
                                    .ExpectedResults
                                    .Include(er => er.Condition)
                                    .Include(er => er.Results)
                                    .SingleOrDefaultAsync(er => er.Id == id);

            if (expectedResult == null)
            {
                return NotFound();
            }

            return View(expectedResult);
        }

        // GET: conditions/Create/1
        public IActionResult Create(int? id)
        {
            var expectedResult = new ExpectedResult
            {
                ConditionId = id.GetValueOrDefault()
            };

            ViewData["ConditionId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", expectedResult.ConditionId);

            return View(expectedResult);
        }

        // POST: conditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ExpectedResult.BindableProperties)] ExpectedResult expectedResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expectedResult);

                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "AcceptanceCriterias", new { Id = expectedResult.ConditionId });
            }

            ViewData["ConditionId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", expectedResult.ConditionId);

            return View(expectedResult);
        }

        // GET: conditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expectedResult = await _context
                                    .ExpectedResults
                                    .SingleOrDefaultAsync(er => er.Id == id);

            if (expectedResult == null)
            {
                return NotFound();
            }

            ViewData["ConditionId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", expectedResult.ConditionId);

            return View(expectedResult);
        }

        // POST: conditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ExpectedResult.BindablePropertiesForEdition)] ExpectedResult expectedResult)
        {
            if (id != expectedResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expectedResult);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpectedResultExists(expectedResult.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "AcceptanceCriterias", new { Id = expectedResult.ConditionId });
            }

            ViewData["ConditionId"] = new SelectList(_context.AcceptanceCriterias, "Id", "Name", expectedResult.ConditionId);

            return View(expectedResult);
        }

        // GET: conditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expectedResult = await _context
                                    .ExpectedResults
                                    .Include(er => er.Condition)
                                    .SingleOrDefaultAsync(er => er.Id == id);

            if (expectedResult == null)
            {
                return NotFound();
            }

            return View(expectedResult);
        }

        // POST: conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expectedResult = await _context
                                    .ExpectedResults
                                    .SingleOrDefaultAsync(er => er.Id == id);

            _context.ExpectedResults.Remove(expectedResult);

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "AcceptanceCriterias", new { Id = expectedResult.ConditionId });
        }

        private bool ExpectedResultExists(int id)
        {
            return _context.Results.Any(e => e.Id == id);
        }
    }
}