using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Common.Services;
using ProjectRunner.Common.Tools;
using ProjectRunner.Common.Validators;
using ProjectRunner.Desktop.Contracts;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProjectRunner.Desktop.Forms
{
    public partial class ExecutableForm : Form
    {
        public OnRecordSavedEvent<Executable> OnExecutableSaved;
        public Executable Executable { get; private set; }
        private IRepositoryService<Executable> _service;

        public ExecutableForm()
        {
            InitializeComponent();
            Initalization();
        }
        public ExecutableForm(Executable executable)
        {
            InitializeComponent();
            Initalization(executable);
        }

        public void SetExecutable(Executable executable)
        {
            Executable = executable;
        }

        private void Initalization(Executable executable = null)
        {
            MaximizeBox = false;
            Text = Resources.Strings.Insert + " " + Resources.Strings.Executable;
            LblName.Text = Resources.Strings.Name;
            LblFileName.Text = Resources.Strings.FileName;
            BtnSave.Text = Resources.Strings.Save;

            _service = new BaseRepositoryService<Executable>(new BaseRepository<Executable>(new SQLiteContext()));

            if (executable != null)
            {
                LoadExecutable(executable);
            }
        }

        private void BtnOpenFileDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = OFDExecutable.ShowDialog();

            if (result == DialogResult.OK)
            {
                TbFileName.Text = OFDExecutable.FileName;
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            if (Executable == null || Executable.Id == 0)
            {
                SetExecutable(new Executable());
            }

            Executable.Name = TbName.Text.Trim();
            Executable.FileName = TbFileName.Text.Trim();

            try
            {
                _service.Save<ExecutableValidator>(Executable);
                MessageBox.Show(Resources.Strings.ExecutableSaveSuccess);
                OnExecutableSaved(Executable);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Utils.HandleExceptionMessage(ex));
            }
        }

        private void LoadExecutable(Executable executable)
        {
            SetExecutable(executable);

            TbName.Text = Executable.Name;
            TbFileName.Text = Executable.FileName;
            OFDExecutable.InitialDirectory = Path.GetDirectoryName(Executable.FileName);
            OFDExecutable.FileName = Path.GetFileName(Executable.FileName);
        }
    }
}
