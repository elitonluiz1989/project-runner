using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Contracts;
using ProjectRunner.WPF.Mapping;
using ProjectRunner.WPF.Services;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.Tools;
using ProjectRunner.WPF.ViewModels;
using ProjectRunner.WPF.ViewModels.Executables;
using System;
using System.Windows;

namespace ProjectRunner.WPF
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<SQLiteContext>();
            services.AddSingleton<BaseRepository<Project>>();
            services.AddSingleton<BaseRepository<Executable>>();

            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ExecutablesStore>();

            services.AddTransient<ProjectsViewModel>();
            services.AddTransient<ExecutablesViewModel>();
            services.AddTransient<ExecutableViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddSingleton<NavigationViewModel>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<ProjectsNavigationService>();
            services.AddSingleton<ExecutablesNavigationService>();
            services.AddSingleton<SettingsNavigationService>();

            services.AddSingleton<ShowProductFormCommand>();
            services.AddSingleton<ShowExecutablesFormCommand>();

            services.AddSingleton(s => new MainWindow() { DataContext = s.GetRequiredService<MainViewModel>() });

            _serviceProvider = services.BuildServiceProvider();
        }

        public async void AppStartup(object sender, StartupEventArgs e)
        {
            SQLiteContext dbContext = _serviceProvider.GetRequiredService<SQLiteContext>();
            await dbContext.InitializeDatabase();

            ServiceProviderAccessor.Initialize(_serviceProvider);
            AppMapper.Initialize();

            INavigationService navigationService = _serviceProvider.GetRequiredService<ProjectsNavigationService>();
            navigationService.Navigate();

            MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}