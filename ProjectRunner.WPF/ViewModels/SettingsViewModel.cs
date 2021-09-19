using ProjectRunner.WPF.Stores;

namespace ProjectRunner.WPF.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        private NavigationStore _navigationStore;

        public SettingsViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}