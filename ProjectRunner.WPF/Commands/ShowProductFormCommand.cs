using ProjectRunner.WPF.Views.Forms;

namespace ProjectRunner.WPF.Commands
{
    public class ShowProductFormCommand : Command
    {
        public override void Execute(object parameter)
        {
            ProjectForm projectForm = new();
            projectForm.ShowDialog();
        }
    }
}
