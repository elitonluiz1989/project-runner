using ProjectRunner.WPF.Stores;

namespace ProjectRunner.WPF.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public NavigationViewModel NavigationViewModel { get; }
        public ViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        private readonly NavigationStore _navigationStore;

        public MainViewModel(
            NavigationViewModel navigationViewModel,
            NavigationStore navigationStore
        )
        {
            NavigationViewModel = navigationViewModel;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        public override void Dispose()
        {
            _navigationStore.CurrentViewModelChanged -= OnCurrentViewModelChanged;
            CurrentViewModel.Dispose();

            base.Dispose();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
