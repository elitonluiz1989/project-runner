using ProjectRunner.WPF.Stores;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ProjectRunner.WPF.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public ViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public NavigationViewModel NavigationViewModel { get; set; }
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationViewModel navigationViewModel, NavigationStore navigationStore)
        {
            NavigationViewModel = navigationViewModel;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
