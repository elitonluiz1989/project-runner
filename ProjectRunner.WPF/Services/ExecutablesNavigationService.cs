using ProjectRunner.WPF.Contracts;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;

namespace ProjectRunner.WPF.Services
{
    public class ExecutablesNavigationService : INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly ExecutablesViewModel _viewModel;

        public ExecutablesNavigationService(
            NavigationStore navigationStore,
            ExecutablesViewModel viewModel
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
