using ProjectRunner.WPF.Views.Forms;

namespace ProjectRunner.WPF.Commands
{
    public class ShowExecutablesFormCommand : Command
    {
        public override void Execute(object parameter)
        {
            ExecutableForm executableForm = new();
            executableForm.ShowDialog();
        }
    }
}
