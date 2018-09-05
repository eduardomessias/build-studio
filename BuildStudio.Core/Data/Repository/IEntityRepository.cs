using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace BuildStudio.Core.Data.Repository
{
    using Base;
    using Base.Model;
    
    public interface IEntityRepository<TContext, TEntity>
        where TContext : DbContext 
        where TEntity : BindableEntity
    {
        TEntity Construct(IUserEntity createdBy);

        #region Create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        #endregion

        #region Read
        List<TEntity> Read();
        List<TEntity> Read(Expression<Func<TEntity, bool>> predicate);
        TEntity Read(int id);
        List<TEntity> Read(string createdBy);

        Task<List<TEntity>> ReadAsync();
        Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> ReadAsync(int id);
        Task<List<TEntity>> ReadAsync(string createdBy);
        #endregion

        #region Update
        EntityEntry<TEntity> Update(TEntity entity);
        Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity);
        #endregion

        #region Delete
        EntityEntry<TEntity> Delete(TEntity entity);
        Task<EntityEntry<TEntity>> DeleteAsync(TEntity entity);
        #endregion

        #region Util
        bool Exists(int id);
        Task<bool> ExistsAsync(int id);

        Task<List<TParent>> ReadParentSetAsync<TParent>() where TParent : Entity;
        Task<TParent> ReadParentAsync<TParent>(int id) where TParent : Entity;
        #endregion
    }
}
