using ProjectRunner.WPF.Views;

namespace ProjectRunner.WPF.Commands
{
    public class ShowProductFormCommand : Command
    {
        public override void Execute(object parameter)
        {
            ProjectView projectView = new();
            projectView.ShowDialog();
        }
    }
}
