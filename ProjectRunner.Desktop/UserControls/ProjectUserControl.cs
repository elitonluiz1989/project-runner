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
        private int _proccesIndex;
        private bool _isRunning;

        public ProjectUserControl(Project project)
        {
            InitializeComponent();

            BaseRepositoryService<Project> service = new(new BaseRepository<Project>(new SQLiteContext()));
            ProjectRunnerService.SetRepositoryService(service);
            _processOutputService = new TerminalOutputService();
            SetProject(project);
            MSManageItems.Text = Resources.Strings.Manage;
            MSManageEditItem.Text = Resources.Strings.Edit;
            MSManageRemoveItem.Text = Resources.Strings.Remove;
            MSManageShowLog.Text = Resources.Strings.Log;
        }

        #region Menu Actions Events

        private void MSManageEditItem_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new(_project) { StartPosition = FormStartPosition.CenterParent };
            projectForm.OnProjectSaved = (Project project) => EditActionEvent(this, project);
            projectForm.ShowDialog();
        }

        private void MSManageRemoveItem_Click(object sender, EventArgs e)
        {
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

        private void MSManageShowLog_Click(object sender, EventArgs e)
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
                    ProjectRunnerService.Stop(_proccesIndex);
                    _isRunning = false;
                }
                else
                {
                    _isRunning = true;
                    SetActionButtonText();

                    await ProjectRunnerService.Run(_proccesIndex)
                        .ContinueWith(t => {
                            ProjectRunnerService.Stop(_proccesIndex);
                            _isRunning = false;
                        });
                }
            }
            catch (Exception ex)
            {
                _isRunning = false;
                MessageBox.Show(Utils.HandleExceptionMessage(ex));
            }

            SetActionButtonText();
        }

        public void SetProject(Project project)
        {
            _project = project;
            LblProject.Text = _project.Name;
            ProjectRunnerDto dto = new()
            {
                Project = _project,
                ProcessOutputService = _processOutputService
            };

            if (_proccesIndex == 0)
            {
                _proccesIndex = ProjectRunnerService.Create(dto);
            }
            else
            {
                ProjectRunnerService.Update(_proccesIndex, dto);
            }

            SetTerminalOutput();
        }

        private void SetActionButtonText()
        {
            BtnAction.Text = _isRunning ? Resources.Strings.Stop : Resources.Strings.Run;
        }

        private void SetTerminalOutput()
        {
            _processOutputService.SetBeginOutputHandler(ProjectRunnerService.BeginOutputReadLine, _proccesIndex);
            _processOutputService.SetCancelOutputHandler(ProjectRunnerService.CancelOutputRead, _proccesIndex);
        }

    }
}
