using Microsoft.EntityFrameworkCore;
using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Infra.Data.Repository
{

    public class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        protected readonly SQLiteContext SQLiteContext;

        public BaseRepository(SQLiteContext dbContext)
        {
            SQLiteContext = dbContext;
        }

        public void Insert(Entity obj)
        {
            SQLiteContext.Set<Entity>().Add(obj);
            SQLiteContext.SaveChanges();
        }

        public void Update(Entity obj)
        {
            SQLiteContext.Entry(obj).State = EntityState.Modified;
            SQLiteContext.SaveChanges();
        }

        public void Delete(int id)
        {
            SQLiteContext.Set<Entity>().Remove(Select(id));
            SQLiteContext.SaveChanges();
        }

        public IList<Entity> Select()
        {
            var query = SelectQueryBuilder();

            return query.ToList();
        }

        public IList<Entity> Select(Func<IQueryable<Entity>, IQueryable<Entity>> filter)
        {
            var query = SelectQueryBuilder(filter);

            return query.ToList();
        }

        public Entity Select(int id)
        {
            var query = SelectQueryBuilder();

            return query.FirstOrDefault(e => e.Id == id);
        }

        public Entity Select(int id, Func<IQueryable<Entity>, IQueryable<Entity>> filter)
        {
            var query = SelectQueryBuilder(filter);

            return query.FirstOrDefault(e => e.Id == id);
        }

        private IQueryable<Entity> SelectQueryBuilder(Func<IQueryable<Entity>, IQueryable<Entity>> filter = null)
        {
            IQueryable<Entity> query = SQLiteContext.Set<Entity>();

            if (filter != null)
            {
                query = filter(query);
            }

            return query;
        }
    }
}
