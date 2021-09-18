using ProjectRunner.WPF.Services;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;

namespace ProjectRunner.WPF.Commands
{
    public class NavigateCommand<T> : Command
        where T : ViewModel
    {
        private readonly NavigationService<T> _navigationService;

        public NavigateCommand(NavigationService<T> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
