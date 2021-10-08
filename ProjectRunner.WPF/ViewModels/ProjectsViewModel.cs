using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectRunner.WPF.ViewModels
{
    public class ProjectsViewModel : RecordsManagementViewModel
    {
        private NavigationStore _navigationStore;
        private ProjectRepository _projectRepository;

        public ProjectsViewModel(
            NavigationStore navigationStore,
            ProjectRepository projectRepository
        )
        {
            _navigationStore = navigationStore;
            _projectRepository = projectRepository;
            GetProjects();
        }

        private void GetProjects()
        {
             _records = new ObservableCollection<Project>();

            List<Project> projects = _projectRepository.All() as List<Project>;

            foreach (Project project in projects)
            {
                _records.Add(project);
            }
        }
    }
}