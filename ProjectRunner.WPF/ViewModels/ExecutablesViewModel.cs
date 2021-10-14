using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Stores;

namespace ProjectRunner.WPF.ViewModels
{
    public class ExecutablesViewModel : RecordsManagementViewModel<Executable>
    {
        private NavigationStore _navigationStore;

        public ExecutablesViewModel(
            NavigationStore navigationStore,
            BaseRepository<Executable> executablesRepository,
            ShowExecutablesFormCommand showExecutablesFormCommand
        ) : base(executablesRepository)
        {
            _navigationStore = navigationStore;
            ShowRecordFormCommand = showExecutablesFormCommand;
            GetRecords();
        }
    }
}