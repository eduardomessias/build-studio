using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BuildStudio.Data.Repository
{
    using Core.Extensions;
    using Data.Model;
    using Core.Data.Repository;
    using BuildStudio.Core.Data.Base;
    using BuildStudio.Core.Data.Base.Model;

    public class FsRepository : EntityRepository<DbContext, FunctionalSpecification>
    {
        public FsRepository(DbContext context)
            : base(context)
        {
            // Write something or leave it blank, but don't erase this!
        }

        public override FunctionalSpecification Construct(IUserEntity createdBy)
        {
            var fs = base.Construct(createdBy) as FunctionalSpecification;

            fs.Author = createdBy.FullName;

            return fs;
        }

        public override async Task<List<FunctionalSpecification>> ReadAsync(string createdBy) =>
            createdBy.IsNullOrEmpty() ? await ReadAsync() : await ReadAsync(fs => fs.CreatedBy == createdBy);

        public override async Task<FunctionalSpecification> ReadAsync(int id) =>
            await context.Set<FunctionalSpecification>().Include(fs => fs.Functionalities).FirstOrDefaultAsync(fs => fs.Id == id);
    }
}
