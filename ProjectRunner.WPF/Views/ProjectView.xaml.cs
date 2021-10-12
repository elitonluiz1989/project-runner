using System.Windows;

namespace ProjectRunner.WPF.Views
{
    /// <summary>
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    public partial class ProjectView : Window
    {
        public ProjectView()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
        }
    }
}
