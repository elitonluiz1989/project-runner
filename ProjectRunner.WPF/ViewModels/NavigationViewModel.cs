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
            ProjectsNavigationService projectsNavigationService,
            ExecutablesNavigationService executablesNavigationService,
            SettingsNavigationService settingsNavigationService
        )
        {
            NavigateProjectsCommand = new NavigateCommand(projectsNavigationService);
            NavigateExecutablesCommand = new NavigateCommand(executablesNavigationService);
            NavigateSettingsCommand = new NavigateCommand(settingsNavigationService);
        }
    }
}
