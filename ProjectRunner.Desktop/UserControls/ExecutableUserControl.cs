using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Common.Services;
using ProjectRunner.Common.Tools;
using ProjectRunner.Desktop.Contracts;
using ProjectRunner.Desktop.Forms;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using System;
using System.Windows.Forms;

namespace ProjectRunner.Desktop.UserControls
{
    public partial class ExecutableUserControl : UserControl
    {
        public EditActionEvent<ExecutableUserControl, Executable> EditActionEvent { get; set; }
        public RemoveActionEvent<ExecutableUserControl> RemoveActionEvent { get; set; }
        public Executable Executable { get; private set; }
        private IRepositoryService<Executable> _service;

        public ExecutableUserControl(Executable executable)
        {
            InitializeComponent();

            SetExecutable(executable);
            _service = new BaseRepositoryService<Executable>(new BaseRepository<Executable>(new SQLiteContext()));
        }

        private void MSIEdit_Click(object sender, EventArgs e)
        {
            ExecutableForm executableForm = new(Executable) { StartPosition = FormStartPosition.CenterParent };
            executableForm.OnExecutableSaved = (Executable executable) => EditActionEvent(this, executable);
            executableForm.ShowDialog();
        }

        private void MSIRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Resources.Strings.ExecutableRemoveQuestion, Resources.Strings.ExecutableRemove, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    _service.Destroy(Executable.Id);
                    MessageBox.Show(Resources.Strings.ExecutableRemoveSuccess);
                    RemoveActionEvent(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Utils.HandleExceptionMessage(ex));
                }
            }
        }

        public void SetExecutable(Executable executable)
        {
            Executable = executable;
            LblName.Text = Executable.Name;
        }
    }
}
