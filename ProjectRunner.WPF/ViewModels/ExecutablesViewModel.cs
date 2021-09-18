using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Services;
using ProjectRunner.WPF.Stores;
using System.Windows.Input;

namespace ProjectRunner.WPF.ViewModels
{
    public class ExecutablesViewModel : ViewModel
    {
        public ICommand NavigationProjectsCommand { get; set; }
        private readonly NavigationViewModel _navigationViewModel;

        public ExecutablesViewModel(NavigationViewModel navigationViewModel, NavigationStore navigationStore)
        {
            _navigationViewModel = navigationViewModel;
            NavigationProjectsCommand = new NavigateCommand<ProjectsViewModel>(
                new NavigationService<ProjectsViewModel>(
                    navigationStore,
                    () => new ProjectsViewModel(navigationViewModel, navigationStore)
                )
            );
        }
    }
}
