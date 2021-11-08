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
            _store = store;
            Owner = Application.Current.MainWindow;
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
                Executable executable = _viewModel.CastTo<Executable>();
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
            _viewModel = ExecutableViewModel.CreateFrom(executable);
            DataContext = _viewModel;
        }

        public void Dispose()
        {
            FormControlsComponent.OnCancel -= CancelEvent;
            FormControlsComponent.OnSave -= SaveEvent;
        }
    }
}
