using System.Windows.Controls;

namespace ProjectRunner.WPF.Views.Components
{
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
            BtnProjects.Focus();
        }
    }
}
