using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Stores;

namespace ProjectRunner.WPF.ViewModels
{
    public class ProjectsViewModel : RecordsManagementViewModel<Project>
    {
        private NavigationStore _navigationStore;

        public ProjectsViewModel(
            NavigationStore navigationStore,
            BaseRepository<Project> projectRepository,
            ShowProductFormCommand showProjectFormCommand
        ) : base(projectRepository)
        {
            _navigationStore = navigationStore;
            ShowRecordFormCommand = showProjectFormCommand;
            GetRecords();
        }
    }
}