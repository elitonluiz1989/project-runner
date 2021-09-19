using ProjectRunner.WPF.Contracts;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;

namespace ProjectRunner.WPF.Services
{
    public class SettingsNavigationService : INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly SettingsViewModel _viewModel;

        public SettingsNavigationService(
            NavigationStore navigationStore,
            SettingsViewModel viewModel
        )
        {
            _navigationStore = navigationStore;
            _viewModel = viewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _viewModel;
        }
    }
}
