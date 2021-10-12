using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Dto;
using ProjectRunner.Common.Entities;
using ProjectRunner.Common.Services;
using ProjectRunner.Common.Tools;
using ProjectRunner.Desktop.Contracts;
using ProjectRunner.Desktop.Forms;
using ProjectRunner.Desktop.Services;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using System;
using System.Windows.Forms;

namespace ProjectRunner.Desktop.UserControls
{
    public partial class ProjectUserControl : UserControl
    {
        public EditActionEvent<ProjectUserControl, Project> EditActionEvent { get; set; }
        public RemoveActionEvent<ProjectUserControl> RemoveActionEvent { get; set; }
        private Project _project;
        private IProcessOutputService _processOutputService;
        private int _projectIndex;
        private bool _isRunning;

        public ProjectUserControl(Project project)
        {
            InitializeComponent();

            BaseRepositoryService<Project> service = new(new BaseRepository<Project>(new SQLiteContext()));
            //ProjectRunnerService.SetRepositoryService(service);
            _processOutputService = new ProcessOutputService();
            SetProject(project);
            SetActionButtonText();
            MSManageItems.Text = Resources.Strings.Manage;
            MSManageEditItem.Text = Resources.Strings.Edit;
            MSManageRemoveItem.Text = Resources.Strings.Remove;
            MSManageOutput.Text = Resources.Strings.ProcessOutput;
        }

        #region Menu Actions Events

        private void MSManageEditItem_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show(Resources.Strings.DenyActionWhenProjectRunning);
                return;
            }

            ProjectForm projectForm = new(_project) { StartPosition = FormStartPosition.CenterParent };
            projectForm.OnProjectSaved = (Project project) => EditActionEvent(this, project);
            projectForm.ShowDialog();
        }

        private void MSManageRemoveItem_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show(Resources.Strings.DenyActionWhenProjectRunning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(Resources.Strings.ProjectRemoveQuestion, Resources.Strings.ProjectRemove, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                BaseRepositoryService<Project> service = new(new BaseRepository<Project>(new SQLiteContext()));

                try
                {
                    service.Destroy(_project.Id);
                    MessageBox.Show(Resources.Strings.ProjectRemoveSuccess);
                    RemoveActionEvent(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Utils.HandleExceptionMessage(ex));
                }
            }
        }

        private void MSManageOutput_Click(object sender, EventArgs e)
        {
            _processOutputService.Show();
        }

        #endregion

        private async void BtnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isRunning)
                {
                    ProjectRunnerService.Stop(_projectIndex);
                    _isRunning = false;
                }
                else
                {
                    _isRunning = true;
                    ManageControlsForRunningProject();

                    await ProjectRunnerService.Run(_projectIndex)
                        .ContinueWith(t => {
                            ProjectRunnerService.Stop(_projectIndex);
                            _isRunning = false;
                        });
                }
            }
            catch (Exception ex)
            {
                _isRunning = false;
                MessageBox.Show(Utils.HandleExceptionMessage(ex));
            }

            ManageControlsForRunningProject();
        }

        public void SetProject(Project project)
        {
            if (_isRunning)
            {
                MessageBox.Show(Resources.Strings.DenyActionWhenProjectRunning);
                return;
            }

            ProjectRunnerDto dto = ProjectAlreadyCreated() ? ProjectRunnerService.Get(_projectIndex) : new();

            _project = project;
            dto.Project = _project;
            LblProject.Text = _project.Name;

            if (ProjectAlreadyCreated())
            {
                ProjectRunnerService.Update(_projectIndex, dto);
            }
            else
            {
                dto.ProcessOutputService = _processOutputService;
                _projectIndex = ProjectRunnerService.Create(dto);
                SetTerminalOutput();
            }
        }

        private void SetActionButtonText()
        {
            BtnAction.Text = _isRunning ? Resources.Strings.Stop : Resources.Strings.Run;
        }

        private void EnableManagementActions(bool enable = true)
        {
            MSManageEditItem.Enabled = enable;
            MSManageRemoveItem.Enabled = enable;
            MSManageOutput.Enabled = !enable;
        }

        private void ManageControlsForRunningProject()
        {
            SetActionButtonText();
            EnableManagementActions(!_isRunning);
        }

        private void SetTerminalOutput()
        {
            _processOutputService.SetBeginOutputHandler(ProjectRunnerService.BeginOutputReadLine, _projectIndex);
            _processOutputService.SetCancelOutputHandler(ProjectRunnerService.CancelOutputRead, _projectIndex);
        }

        private bool ProjectAlreadyCreated()
        {
            return _projectIndex > 0;
        }
    }
}
