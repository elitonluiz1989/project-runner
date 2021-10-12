using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectRunner.WPF.ViewModels
{
    public abstract class RecordsManagementViewModel<TEntity> : ViewModel
        where TEntity : BaseEntity
    {
        private ObservableCollection<TEntity> _records;
        public IEnumerable<TEntity> Records => _records;
        public ICommand ShowRecordFormCommand { get; set; }
        protected IBaseRepository<TEntity> Repository;

        public RecordsManagementViewModel(IBaseRepository<TEntity> repository)
        {
            Repository = repository;
        }

        protected void GetRecords()
        {
            _records = new ObservableCollection<TEntity>();
            List<TEntity> records = Repository.All() as List<TEntity>;

            foreach (TEntity record in records)
            {
                _records.Add(record);
            }
        }
    }
}