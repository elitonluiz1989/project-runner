using System.Windows.Controls;

namespace ProjectRunner.WPF.Components
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
