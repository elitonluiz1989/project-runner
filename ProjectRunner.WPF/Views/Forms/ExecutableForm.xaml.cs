using System.Windows;

namespace ProjectRunner.WPF.Views.Forms
{
    public partial class ExecutableForm : Window
    {
        public ExecutableForm()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
