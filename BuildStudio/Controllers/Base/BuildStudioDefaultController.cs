using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace BuildStudio.Controllers.Base
{
    using Interface;
    using Data;
    using Models;

    using Core.Data.Base.Model;
    using Core.Data.Repository;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections;
    using BuildStudio.Core.Extensions;
    using System;
    using System.Diagnostics;

    public class BuildStudioDefaultController<TContext, TEntity> : Controller, IBuildStudioDefaultController<TContext, TEntity>
        where TContext : ApplicationDbContext
        where TEntity : BindableEntity
    {
        protected IEntityRepository<TContext, TEntity> repository;
        protected UserManager<ApplicationUser> userManager;

        #region Constructors
        public BuildStudioDefaultController() { }

        public BuildStudioDefaultController(TContext context)
        {
            repository = new EntityRepository<TContext, TEntity>(context);
        }

        public BuildStudioDefaultController(TContext context, UserManager<ApplicationUser> userManager)
        {
            repository = new EntityRepository<TContext, TEntity>(context);
    
            this.userManager = userManager;
        }
        #endregion


        public virtual async Task<IActionResult> Index()
        {
            var entities = await repository.ReadAsync();

            return View(entities);
        }
        public virtual async Task<IActionResult> CreatedBy(string createdBy)
        {
            var entities = await repository.ReadAsync(createdBy);

            return View("Index", entities);
        }

        public virtual async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var entity = await repository.ReadAsync(id.Value);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        public virtual async Task<IActionResult> Create(int? id)
        {
            var user = await userManager.GetUserAsync(User);

            var entity = repository.Construct(user);
            
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(TEntity entity)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(entity);

                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public virtual async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var entity = await repository.ReadAsync(id.Value);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateAsync(entity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!repository.Exists(entity.Id))
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
            return View(entity);
        }

        public virtual async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var entity = await repository.ReadAsync(id.Value);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await repository.ReadAsync(id);

            repository.Delete(entity);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public static class ViewExtensions
    {
        public static IActionResult WithParentViewData(this IActionResult view, IEnumerable parentSet, string viewDataKey = "ParentId", string dataValueField = "Id", string dataTextField = "Name", object parentId = null)
        {
            ((ViewResult)view).ViewData[viewDataKey] = new SelectList(parentSet, dataValueField, dataTextField, parentId);

            return view;
        }
    }
}
