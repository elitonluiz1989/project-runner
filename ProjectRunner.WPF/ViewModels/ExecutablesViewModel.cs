using ProjectRunner.WPF.Stores;

namespace ProjectRunner.WPF.ViewModels
{
    public class ExecutablesViewModel : ViewModel
    {
        private NavigationStore _navigationStore;

        public ExecutablesViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}