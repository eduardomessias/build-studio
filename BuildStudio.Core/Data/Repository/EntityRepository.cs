using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuildStudio.Core.Data.Repository
{
    using Base;
    using Base.Model;
    

    public class EntityRepository<TContext, TEntity> : IEntityRepository<TContext, TEntity> 
        where TContext: DbContext 
        where TEntity : BindableEntity
        
    {
        protected readonly TContext context;

        public EntityRepository(TContext context)
        {
            this.context = context;
        }

        public virtual TEntity Construct(IUserEntity createdBy)
        {
            var entity = Activator.CreateInstance<TEntity>();

            entity.Creation = DateTime.Now;
            entity.CreatedBy = createdBy.Id;

            entity.Update = DateTime.Now;
            entity.ModifiedBy = createdBy.Id;

            entity.Active = true;

            return entity;
        }

        #region Create
        public virtual void Create(TEntity entity)
        {
            context.Add(entity);

            context.SaveChanges();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            context.Add(entity);

            await context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public virtual List<TEntity> Read() => context?.Set<TEntity>()?.ToList();
        public virtual List<TEntity> Read(Expression<Func<TEntity, bool>> predicate) => context?.Set<TEntity>()?.Where(predicate)?.ToList();
        public virtual TEntity Read(int id) => context?.Set<TEntity>()?.FirstOrDefault(entity => entity.Id == id);
        public virtual List<TEntity> Read(string createdBy) => context?.Set<TEntity>()?.Where(entity => entity.CreatedBy == createdBy).ToList();

        public virtual async Task<List<TEntity>> ReadAsync() => await context?.Set<TEntity>()?.ToListAsync();
        public virtual async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate) => await context?.Set<TEntity>()?.Where(predicate)?.ToListAsync();
        public virtual async Task<TEntity> ReadAsync(int id) => await context?.Set<TEntity>()?.FirstOrDefaultAsync(entity => entity.Id == id);
        public virtual async Task<List<TEntity>> ReadAsync(string createdBy) => await context?.Set<TEntity>()?.Where(entity => entity.CreatedBy == createdBy).ToListAsync();
        #endregion

        #region Update
        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            try
            {
                var entityEntry = context.Update(entity);

                context.SaveChanges();

                return entityEntry;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public virtual async Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity)
        {
            try
            {
                var entityEntry = context.Update(entity);

                await context.SaveChangesAsync();

                return entityEntry;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public virtual EntityEntry<TEntity> Delete(TEntity entity)
        {
            var entityEntry = context.Set<TEntity>().Remove(entity);

            context.SaveChanges();

            return entityEntry;
        }

        public virtual async Task<EntityEntry<TEntity>> DeleteAsync(TEntity entity)
        {
            var entityEntry = context.Set<TEntity>().Remove(entity);

            await SaveChangesAsync();

            return entityEntry;
        }
        #endregion

        #region Utils
        public virtual bool Exists(int id) => context.Set<TEntity>().Any(entity => entity.Id == id);
        public virtual async Task<bool> ExistsAsync(int id) => await context.Set<TEntity>().AnyAsync(entity => entity.Id == id);

        public virtual async Task<List<TParent>> ReadParentSetAsync<TParent>() where TParent : Entity => await context.Set<TParent>().ToListAsync();
        public virtual async Task<TParent> ReadParentAsync<TParent>(int id) where TParent : Entity => await context.Set<TParent>().SingleOrDefaultAsync(pr => pr.Id == id);
        #endregion

        #region SaveChanges
        void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        async Task SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        #endregion
    }
}
