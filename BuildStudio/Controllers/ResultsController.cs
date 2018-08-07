using System.Linq;
using System.Threading.Tasks;
using BuildStudio.Data;
using BuildStudio.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BuildStudio.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultsController(ApplicationDbContext context)
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

            var result = await _context
                                    .Results
                                    .Include(rs => rs.ExpectedResult)
                                    .SingleOrDefaultAsync(rs => rs.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: conditions/Create/1
        public IActionResult Create(int? id)
        {
            var result = new Result
            {
                ExpectedResultId = id.GetValueOrDefault()
            };

            ViewData["ExpectedResultId"] = new SelectList(_context.ExpectedResults, "Id", "Name", result.ExpectedResultId);

            return View(result);
        }

        // POST: conditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Result.BindableProperties)] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);

                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "ExpectedResults", new { Id = result.ExpectedResultId });
            }

            ViewData["ExpectedResultId"] = new SelectList(_context.ExpectedResults, "Id", "Name", result.ExpectedResultId);

            return View(result);
        }

        // GET: conditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context
                                    .Results
                                    .SingleOrDefaultAsync(rs => rs.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            ViewData["ExpectedResultId"] = new SelectList(_context.ExpectedResults, "Id", "Name", result.ExpectedResultId);

            return View(result);
        }

        // POST: conditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(Result.BindablePropertiesForEdition)] Result result)
        {
            if (id != result.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultExists(result.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "ExpectedResults", new { Id = result.ExpectedResultId });
            }

            ViewData["ExpectedResultId"] = new SelectList(_context.ExpectedResults, "Id", "Name", result.ExpectedResultId);

            return View(result);
        }

        // GET: conditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context
                                    .Results
                                    .Include(rs => rs.ExpectedResult)
                                    .SingleOrDefaultAsync(rs => rs.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _context
                                    .Results
                                    .SingleOrDefaultAsync(rs => rs.Id == id);

            _context.Results.Remove(result);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "ExpectedResults", new { Id = result.ExpectedResultId });
        }

        private bool ResultExists(int id)
        {
            return _context.Results.Any(e => e.Id == id);
        }
    }
}