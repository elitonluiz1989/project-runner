using Microsoft.Extensions.DependencyInjection;
using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Contracts;
using ProjectRunner.WPF.Services;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels;
using ProjectRunner.WPF.Views;
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
            services.AddSingleton<BaseRepository<Project>>();
            services.AddSingleton<BaseRepository<Executable>>();

            services.AddSingleton<NavigationStore>();

            services.AddTransient<ProjectsViewModel>();
            services.AddTransient<ExecutablesViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddSingleton<NavigationViewModel>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<ProjectsNavigationService>();
            services.AddSingleton<ExecutablesNavigationService>();
            services.AddSingleton<SettingsNavigationService>();

            services.AddTransient<ShowProductFormCommand>();
            services.AddTransient<ShowExecutablesFormCommand>();

            services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<MainViewModel>() });

            _servicesProvider = services.BuildServiceProvider();
        }

        public async void AppStartup(object sender, StartupEventArgs e)
        {
            SQLiteContext dbContext = _servicesProvider.GetRequiredService<SQLiteContext>();
            await dbContext.InitializeDatabase();

            INavigationService navigationService = _servicesProvider.GetRequiredService<ProjectsNavigationService>();
            navigationService.Navigate();

            MainWindow mainWindow = _servicesProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}