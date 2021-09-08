using FluentValidation;
using ProjectRunner.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Common.Contracts
{
    public interface IRepositoryService<Entity> where Entity : BaseEntity
    {
        Entity Save<Validator>(Entity entity) where Validator : AbstractValidator<Entity>;
        void Destroy(int id);
        IList<Entity> All();
        IList<Entity> Select(Func<IQueryable<Entity>, IQueryable<Entity>> filter);
        Entity Find(int id);
        Entity Find(int id, Func<IQueryable<Entity>, IQueryable<Entity>> filter);
    }
}
