using ProjectRunner.WPF.Contracts;

namespace ProjectRunner.WPF.Commands
{
    public class NavigateCommand : Command
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
