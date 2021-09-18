using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Services;
using System.Windows.Input;

namespace ProjectRunner.WPF.ViewModels
{
    public class NavigationViewModel : ViewModel
    {
        public ICommand NavigateProjectsCommand { get; }
        public ICommand NavigateExecutablesCommand { get; }
        public ICommand NavigateSettingsCommand { get; }

        public NavigationViewModel(
            NavigationService<ProjectsViewModel> projectNavigationService,
            NavigationService<ExecutablesViewModel> executablesNavigationService,
            NavigationService<SettingsViewModel> settingsNavigationService
        )
        {
            NavigateProjectsCommand = new NavigateCommand<ProjectsViewModel>(projectNavigationService);
            NavigateExecutablesCommand = new NavigateCommand<ExecutablesViewModel>(executablesNavigationService);
            NavigateSettingsCommand = new NavigateCommand<SettingsViewModel>(settingsNavigationService);
        }
    }
}
