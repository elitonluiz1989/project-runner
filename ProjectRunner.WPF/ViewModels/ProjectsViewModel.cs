using ProjectRunner.WPF.Stores;

namespace ProjectRunner.WPF.ViewModels
{
    public class ProjectsViewModel : ViewModel
    {
        private NavigationStore _navigationStore;

        public ProjectsViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}