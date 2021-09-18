using ProjectRunner.WPF.Services;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;
using System.Windows;

namespace ProjectRunner.WPF
{
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationViewModel _navigationViewModel;

        public App()
        {
            _navigationStore = new();
            _navigationViewModel = new(
                CreateProjectsNavigationService(),
                new NavigationService<ExecutablesViewModel>(_navigationStore, () => new ExecutablesViewModel(_navigationViewModel, _navigationStore)),
                new NavigationService<SettingsViewModel>(_navigationStore, () => new SettingsViewModel(_navigationViewModel, _navigationStore))
            );
        }

        public void AppStartup(object sender, StartupEventArgs e)
        {
            NavigationService<ProjectsViewModel> navigationService = CreateProjectsNavigationService();
            navigationService.Navigate();

            MainWindow mainWindow = new()
            {
                DataContext = new MainViewModel(_navigationViewModel, _navigationStore)
            };
            mainWindow.Show();
        }

        private NavigationService<ProjectsViewModel> CreateProjectsNavigationService()
        {
            return new NavigationService<ProjectsViewModel>(_navigationStore, () => new ProjectsViewModel(_navigationViewModel, _navigationStore));
        }
    }
}