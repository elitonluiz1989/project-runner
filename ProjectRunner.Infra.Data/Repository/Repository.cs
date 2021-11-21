using Microsoft.EntityFrameworkCore;
using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly SQLiteContext SQLiteContext;

        public Repository(SQLiteContext dbContext)
        {
            SQLiteContext = dbContext;
        }

        public int Insert(TEntity obj)
        {
            SQLiteContext.Set<TEntity>().Add(obj);
            return SQLiteContext.SaveChanges();
        }

        public int Update(TEntity obj)
        {
            TEntity localContenxtEntity = SQLiteContext.Set<TEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(obj.Id));

            if (localContenxtEntity != null)
            {
                SQLiteContext.Entry(localContenxtEntity).State = EntityState.Detached;
            }

            SQLiteContext.Entry(obj).State = EntityState.Modified;
            return SQLiteContext.SaveChanges();
        }

        public int Delete(int id)
        {
            SQLiteContext.Set<TEntity>().Remove(Select(id));
            return SQLiteContext.SaveChanges();
        }

        public IList<TEntity> Select()
        {
            IQueryable<TEntity> query = SelectQueryBuilder();

            return query.ToList();
        }

        public IList<TEntity> Select(Func<IQueryable<TEntity>, IQueryable<TEntity>> filter)
        {
            IQueryable<TEntity> query = SelectQueryBuilder(filter);

            return query.ToList();
        }

        public TEntity Select(int id)
        {
            IQueryable<TEntity> query = SelectQueryBuilder();

            return query.FirstOrDefault(e => e.Id == id);
        }

        public TEntity Select(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> filter)
        {
            IQueryable<TEntity> query = SelectQueryBuilder(filter);

            return query.FirstOrDefault(e => e.Id == id);
        }

        private IQueryable<TEntity> SelectQueryBuilder(Func<IQueryable<TEntity>, IQueryable<TEntity>> filter = null)
        {
            IQueryable<TEntity> query = SQLiteContext.Set<TEntity>();

            if (filter != null)
            {
                query = filter(query);
            }

            return query;
        }
    }
}
