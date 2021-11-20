using ProjectRunner.WPF.Stores;
using ProjectRunner.WPF.ViewModels.Executables;
using ProjectRunner.WPF.Views.Forms;

namespace ProjectRunner.WPF.Commands
{
    public class ShowExecutablesFormCommand : Command
    {
        private readonly ExecutablesStore _store;

        public ShowExecutablesFormCommand(ExecutablesStore store)
        {
            _store = store;
        }

        public override void Execute(object parameter)
        {
            ExecutableForm executableForm = new(_store, (ExecutableViewModel)parameter);
            executableForm.ShowDialog();
        }
    }
}
