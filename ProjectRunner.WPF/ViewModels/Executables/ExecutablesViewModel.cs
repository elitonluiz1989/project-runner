using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.WPF.Commands;
using ProjectRunner.WPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectRunner.WPF.ViewModels.Executables
{
    public class ExecutablesViewModel : RecordsViewModel<Executable>
    {
        private ExecutablesStore _store;
        public new ObservableCollection<ExecutableViewModel> Records { get; set; }

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

        public new void GetRecords()
        {
            Records = new ObservableCollection<ExecutableViewModel>();
            List<Executable> records = Repository.All() as List<Executable>;

            foreach (Executable record in records)
            {
                Records.Add(ExecutableViewModel.CreateFrom(record));
            }
        }

        private void OnExecutableSaved(Executable executable)
        {
            ExecutableViewModel record = Records.Where(r => r.Id == executable.Id).FirstOrDefault();

            if (record != null)
            {
                record.Name = executable.Name;
                record.FileName = executable.FileName;
            }
            else
            {
                Records.Add(ExecutableViewModel.CreateFrom(executable));
            }
        }

        public override void Dispose()
        {
            _store.ExecutableSaved -= OnExecutableSaved;
            base.Dispose();
        }
    }
}