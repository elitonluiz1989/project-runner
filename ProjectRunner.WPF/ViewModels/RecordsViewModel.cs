using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectRunner.WPF.ViewModels
{
    public abstract class RecordsViewModel<TEntity> : ViewModel
        where TEntity : BaseEntity
    {
        public ObservableCollection<TEntity> Records { get; private set; }
        public ICommand ShowRecordFormCommand { get; set; }
        protected IBaseRepository<TEntity> Repository;

        public RecordsViewModel(IBaseRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public void GetRecords()
        {
            Records = new ObservableCollection<TEntity>();
            List<TEntity> records = Repository.All() as List<TEntity>;

            foreach (TEntity record in records)
            {
                Records.Add(record);
            }
        }
    }
}