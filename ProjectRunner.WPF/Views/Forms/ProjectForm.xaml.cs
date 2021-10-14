using System.Windows;

namespace ProjectRunner.WPF.Views.Forms
{
    public partial class ProjectForm : Window
    {
        public ProjectForm()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
