using FluentValidation;
using ProjectRunner.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Common.Contracts
{
    public interface IBaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public TEntity Save<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;

        public IList<TEntity> All();

        public TEntity Find(int id);

        public TEntity Find(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> filter);
    }
}
