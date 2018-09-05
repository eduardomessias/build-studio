using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BuildStudio.Controllers
{
    using Controllers.Base;

    using Models;

    using Data;
    using Data.Model;
    using Data.Repository;

    [Authorize]
    public class FunctionalSpecificationsController : BuildStudioDefaultController<ApplicationDbContext, FunctionalSpecification>
    {
        private readonly new FsRepository repository;

        public FunctionalSpecificationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
            : base(context, userManager)
        {
            repository = new FsRepository(context);
        }

        // GET: FunctionalSpecifications/Edit/5
        public override async Task<IActionResult> Edit(int? id)
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

            entity.IncreaseVersion();

            return View(entity);
        }
    }
}
