using ProjectRunner.Common.Entities;
using System;
using System.Windows;

namespace ProjectRunner.WPF.Views.Forms
{
    public partial class ExecutableForm : Window, IDisposable
    {
        private Executable _executable { get; set; }

        public ExecutableForm(Executable executable = null)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            DefineEvents();
            FillForm(executable);
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
            MessageBox.Show("Recorded!");
        }

        private void FillForm(Executable executable)
        {
            _executable = executable ?? new();

            FfName.Value = _executable.Name;
            FfFileName.Value = _executable.FileName;
        }

        public void Dispose()
        {
            FormControlsComponent.OnCancel -= CancelEvent;
            FormControlsComponent.OnSave -= SaveEvent;
        }
    }
}
