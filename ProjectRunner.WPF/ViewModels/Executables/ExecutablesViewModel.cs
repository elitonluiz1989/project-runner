using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Stores;
using System.Linq;

namespace ProjectRunner.WPF.ViewModels.Executables
{
    public class ExecutablesViewModel : RecordsViewModel<Executable>
    {
        private ExecutablesStore _store;
        public ExecutablesViewModel(
            BaseRepository<Executable> executablesRepository,
            ExecutablesStore store,
            ShowExecutablesFormCommand showExecutablesFormCommand
        ) : base(executablesRepository)
        {
            _store = store;
            _store.ExecutableSaved += OnExecutableSaved;
            ShowRecordFormCommand = showExecutablesFormCommand;
            GetRecords();
        }

        private void OnExecutableSaved(Executable executable)
        {
            Executable record = Records.Where(r => r.Id == executable.Id).FirstOrDefault();

            if (record != null)
            {
                record.Name = executable.Name;
                record.FileName = executable.FileName;
            }
            else
            {
                Records.Add(executable);
            }
        }

        public override void Dispose()
        {
            _store.ExecutableSaved -= OnExecutableSaved;
            base.Dispose();
        }
    }
}