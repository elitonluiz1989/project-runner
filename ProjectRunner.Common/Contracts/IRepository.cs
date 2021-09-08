using ProjectRunner.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Common.Contracts
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        void Insert(Entity entity);
        void Update(Entity entity);
        void Delete(int id);
        IList<Entity> Select();
        IList<Entity> Select(Func<IQueryable<Entity>, IQueryable<Entity>> filter);
        Entity Select(int id);
        Entity Select(int id, Func<IQueryable<Entity>, IQueryable<Entity>> filter);
    }
}
