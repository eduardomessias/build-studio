using System.Threading.Tasks;

namespace BuildStudio.Controllers.Base.Interface
{
    using Data;
    using Core.Data.Base.Model;
    using Microsoft.AspNetCore.Mvc;

    public interface IBuildStudioDefaultController<TContext, TEntity> 
        where TContext : ApplicationDbContext
        where TEntity : BindableEntity
    {
        Task<IActionResult> Index();
        Task<IActionResult> CreatedBy(string createdBy);
        Task<IActionResult> Details(int? id);
        Task<IActionResult> Create(int? id);
        Task<IActionResult> Create(TEntity entity);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Edit(int id, TEntity entity);
        Task<IActionResult> Delete(int? id);
        Task<IActionResult> DeleteConfirmed(int id);
    }
}
