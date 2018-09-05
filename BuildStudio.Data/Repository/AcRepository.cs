using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace BuildStudio.Data.Repository
{
    using Data.Model;
    using Core.Data.Repository;

    public class AcRepository : EntityRepository<DbContext, AcceptanceCriteria>
    {
        public AcRepository(DbContext context)
            : base(context)
        {
            // Write something or leave it blank, but don't erase this!
        }

        public override async Task<AcceptanceCriteria> ReadAsync(int id) =>
            await context.Set<AcceptanceCriteria>()
                            .Include(ac => ac.Requirement)
                            .Include(ac => ac.Conditions)
                            .FirstOrDefaultAsync(ac => ac.Id == id);
    }
}
