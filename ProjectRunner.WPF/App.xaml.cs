using Microsoft.Extensions.DependencyInjection;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Contracts;
using ProjectRunner.WPF.Services;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;
using System;
using System.Windows;

namespace ProjectRunner.WPF
{
    public partial class App : Application
    {
        private readonly IServiceProvider _servicesProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<SQLiteContext>();
            services.AddSingleton(s => new ProjectRepository(s.GetRequiredService<SQLiteContext>()));

            services.AddSingleton<NavigationStore>();

            services.AddTransient<ProjectsViewModel>();
            services.AddTransient<ExecutablesViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddSingleton<NavigationViewModel>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<ProjectsNavigationService>();
            services.AddSingleton<ExecutablesNavigationService>();
            services.AddSingleton<SettingsNavigationService>();

            services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<MainViewModel>() });

            _servicesProvider = services.BuildServiceProvider();
        }

        public void AppStartup(object sender, StartupEventArgs e)
        {
            INavigationService navigationService = _servicesProvider.GetRequiredService<ProjectsNavigationService>();
            navigationService.Navigate();

            MainWindow mainWindow = _servicesProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}