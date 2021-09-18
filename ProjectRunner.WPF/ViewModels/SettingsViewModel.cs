using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Services;
using ProjectRunner.WPF.Stores;
using System.Windows.Input;

namespace ProjectRunner.WPF.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        public ICommand NavigationExecutablesCommand { get; set; }
        private readonly NavigationViewModel _navigationViewModel;

        public SettingsViewModel(NavigationViewModel navigationViewModel, NavigationStore navigationStore)
        {
            _navigationViewModel = navigationViewModel;
            NavigationExecutablesCommand = new NavigateCommand<ExecutablesViewModel>(
                new NavigationService<ExecutablesViewModel>(
                    navigationStore,
                    () => new ExecutablesViewModel(navigationViewModel, navigationStore)
                )
            );
        }
    }
}
