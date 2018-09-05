using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildStudio.Data;
using BuildStudio.Data.Model;
using Microsoft.AspNetCore.Identity;
using BuildStudio.Models;

namespace BuildStudio.Controllers
{
    using Base;
    using Data.Repository;

    public class AcceptanceCriteriasController : BuildStudioDefaultController<ApplicationDbContext, AcceptanceCriteria>
    {
        private readonly new AcRepository repository;

        public AcceptanceCriteriasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
            : base(context)
        {
            repository = new AcRepository(context);
        }

        public override async Task<IActionResult> Create(int? id)
        {
            var view = await base.Create(id);
            
            return view.WithParentViewData(await repository.ReadParentSetAsync<Requirement>(), parentId: id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind(AcceptanceCriteria.BindableProperties)] AcceptanceCriteria acceptanceCriteria)
        {
            var view = await base.Create(acceptanceCriteria);

            return view.WithParentViewData(await repository.ReadParentSetAsync<Requirement>(), parentId: acceptanceCriteria.RequirementId);
        }

        public override async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var acceptanceCriteria = await repository.ReadAsync(id.Value);

            if (acceptanceCriteria == null)
            {
                return NotFound();
            }

            var view = View(acceptanceCriteria);

            return view.WithParentViewData(await repository.ReadParentSetAsync<Requirement>(), parentId: acceptanceCriteria.RequirementId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int id, [Bind(AcceptanceCriteria.BindablePropertiesForEdition)] AcceptanceCriteria acceptanceCriteria)
        {
            var view = await base.Edit(id, acceptanceCriteria);

            return view.WithParentViewData(await repository.ReadParentSetAsync<Requirement>(), parentId: acceptanceCriteria.RequirementId);
        }
    }
}
