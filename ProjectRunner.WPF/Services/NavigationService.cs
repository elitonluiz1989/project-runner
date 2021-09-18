using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;
using System;

namespace ProjectRunner.WPF.Services
{
    public class NavigationService<T>
        where T : ViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<T> _setViewModel;

        public NavigationService(NavigationStore navigationStore, Func<T> setViewModel)
        {
            _navigationStore = navigationStore;
            _setViewModel = setViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _setViewModel();
        }
    }
}
