using ProjectRunner.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Common.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(int id);
        IList<TEntity> Select();
        IList<TEntity> Select(Func<IQueryable<TEntity>, IQueryable<TEntity>> filter);
        TEntity Select(int id);
        TEntity Select(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> filter);
    }
}
