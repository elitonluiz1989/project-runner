using FluentValidation;
using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Infra.Data.Repository
{

    public class BaseRepository<TEntity> : Repository<TEntity>, IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        public BaseRepository(SQLiteContext dbContext) : base(dbContext)
        { }

        public TEntity Save<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());

            if (entity.Id > 0)
            {
                Update(entity);
            }
            else
            {
                Insert(entity);
            }

            return entity;
        }

        public IList<TEntity> All()
        {
            return Select();
        }

        public TEntity Find(int id)
        {
            return Select(id);
        }

        public TEntity Find(int id, Func<IQueryable<TEntity>, IQueryable<TEntity>> filter)
        {
            return Select(id, filter);
        } 

        private static void Validate(TEntity entity, AbstractValidator<TEntity> validator)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            validator.ValidateAndThrow(entity);
        }
    }
}
