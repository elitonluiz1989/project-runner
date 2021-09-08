using FluentValidation;
using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRunner.Common.Services
{
    public class BaseRepositoryService<Entity> : IRepositoryService<Entity> where Entity : BaseEntity
    {
        private readonly IRepository<Entity> _repository;

        public BaseRepositoryService(IRepository<Entity> baseRepository)
        {
            _repository = baseRepository;
        }

        public Entity Save<Validator>(Entity entity) where Validator : AbstractValidator<Entity>
        {
            Validate(entity, Activator.CreateInstance<Validator>());

            if (entity.Id > 0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Insert(entity);
            }

            return entity;
        }

        public void Destroy(int id) => _repository.Delete(id);

        public IList<Entity> All() => _repository.Select();

        public IList<Entity> Select(Func<IQueryable<Entity>, IQueryable<Entity>> filter) => _repository.Select(filter);

        public Entity Find(int id) => _repository.Select(id);

        public Entity Find(int id, Func<IQueryable<Entity>, IQueryable<Entity>> filter) => _repository.Select(id, filter);

        private static void Validate(Entity entity, AbstractValidator<Entity> validator)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            validator.ValidateAndThrow(entity);
        }
    }
}
