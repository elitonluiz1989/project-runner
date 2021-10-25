using ProjectRunner.Common.Entities;
using ProjectRunner.Common.Validators;
using ProjectRunner.Infra.Data.Repository;
using System;

namespace ProjectRunner.WPF.Stores
{
    public class ExecutablesStore
    {
        public event Action<Executable> ExecutableSaved;
        private BaseRepository<Executable> _repository;

        public ExecutablesStore(BaseRepository<Executable> repository)
        {
            _repository = repository;
        }

        public void Save(Executable executable)
        {
            _repository.Save<ExecutableValidator>(executable);
            ExecutableSaved?.Invoke(executable);
        }
    }
}
