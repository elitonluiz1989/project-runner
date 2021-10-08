using ProjectRunner.Common.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectRunner.WPF.ViewModels
{
    public abstract class RecordsManagementViewModel : ViewModel
    {
        protected ObservableCollection<Project> _records;
        public IEnumerable<Project> Records => _records;

        public ICommand AddRecordCommand { get; }

        public RecordsManagementViewModel()
        {
        }
    }
}