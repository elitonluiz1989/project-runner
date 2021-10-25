using ProjectRunner.Common.Entities;
using ProjectRunner.Common.Tools;
using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels.Executables;
using System;
using System.Windows;

namespace ProjectRunner.WPF.Views.Forms
{
    public partial class ExecutableForm : Window, IDisposable
    {
        private ExecutableViewModel _viewModel;
        private ExecutablesStore _store;

        public ExecutableForm(ExecutablesStore store)
        {
            InitializeComponent();
            _viewModel = new ExecutableViewModel();
            _store = store;
            Owner = Application.Current.MainWindow;
            DataContext = _viewModel;
            DefineEvents();
            FillForm(null);
        }

        private void DefineEvents()
        {
            FormControlsComponent.OnCancel += CancelEvent;
            FormControlsComponent.OnSave += SaveEvent;
        }

        private void CancelEvent(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                Executable executable = new();
                executable.Id = _viewModel.Id;
                executable.Name = _viewModel.Name;
                executable.FileName = _viewModel.FileName;

                _store.Save(executable);

                MessageBox.Show("Executable saved.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utils.HandleExceptionMessage(ex));
            }
        }

        private void FillForm(Executable executable)
        {
            executable ??= new();
            _viewModel.Id = executable.Id;
            _viewModel.Name = executable.Name;
            _viewModel.FileName = executable.FileName;
        }

        public void Dispose()
        {
            FormControlsComponent.OnCancel -= CancelEvent;
            FormControlsComponent.OnSave -= SaveEvent;
        }
    }
}
