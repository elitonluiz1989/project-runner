using ProjectRunner.WPF.Contracts;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;

namespace ProjectRunner.WPF.Services
{
    public class ProjectsNavigationService : INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly ProjectsViewModel _viewModel;

        public ProjectsNavigationService(
            NavigationStore navigationStore,
            ProjectsViewModel viewModel
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
