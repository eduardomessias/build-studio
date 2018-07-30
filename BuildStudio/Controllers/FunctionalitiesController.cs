using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildStudio.Data;
using BuildStudio.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BuildStudio.Controllers
{
    [Authorize]
    public class FunctionalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FunctionalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Functionalities/Create/1
        public IActionResult Create(int? id)
        {
            var functionality = new Functionality
            {
                FunctionalSpecificationId = id.GetValueOrDefault()
            };

            ViewData["FunctionalSpecificationId"] = new SelectList(_context.FunctionalSpecifications, "Id", "Title", functionality.FunctionalSpecificationId);
            
            return View(functionality);
        }

        // POST: Functionalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Functionality.BindableProperties)] Functionality functionality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functionality);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "FunctionalSpecifications", new { Id = functionality.FunctionalSpecificationId });
            }
            return View(functionality);
        }

        // GET: Functionalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionality = await _context
                                    .Functionalities
                                    .Include(fn => fn.FunctionalSpecification)
                                    .SingleOrDefaultAsync(m => m.Id == id);

            if (functionality == null)
            {
                return NotFound();
            }

            return View(functionality);
        }

        // GET: Functionalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionality = await _context.Functionalities.SingleOrDefaultAsync(m => m.Id == id);
            if (functionality == null)
            {
                return NotFound();
            }

            ViewData["FunctionalSpecificationId"] = new SelectList(_context.FunctionalSpecifications, "Id", "Title", functionality.FunctionalSpecificationId);
            return View(functionality);
        }

        // POST: Functionalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(Functionality.BindableProperties)] Functionality functionality)
        {
            if (id != functionality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(functionality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Functionalities.Any(x => x.Id == functionality.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "FunctionalSpecifications", new { Id = functionality.FunctionalSpecificationId });
            }
            return View(functionality);
        }
    }
}