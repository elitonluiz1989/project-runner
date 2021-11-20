using ProjectRunner.WPF.Commands;
using System.Windows.Input;

namespace ProjectRunner.WPF.ViewModels.Executables
{
    public class ExecutableViewModel : ViewModel
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }
        public ICommand ShowFormCommand { get; set; }

        public ExecutableViewModel(ShowExecutablesFormCommand showExecutablesFormCommand)
        {
            ShowFormCommand = showExecutablesFormCommand;
        }

        public static ExecutableViewModel CreateFrom<TType>(TType obj)
        {
            return CreateFrom<TType, ExecutableViewModel>(obj);
        }
    }
}
