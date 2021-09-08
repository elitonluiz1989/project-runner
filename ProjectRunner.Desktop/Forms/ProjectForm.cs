using Microsoft.EntityFrameworkCore;
using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Common.Services;
using ProjectRunner.Common.Tools;
using ProjectRunner.Common.Validators;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using System;
using System.Windows.Forms;

namespace ProjectRunner.Desktop.Forms
{
    public delegate void OnProjectSaved(Project project);

    public partial class ProjectForm : Form
    {
        public OnProjectSaved OnProjectSaved;
        public Project Project { get; private set; }
        private IRepositoryService<Project> _service;

        public ProjectForm()
        {
            InitializeComponent();
            Initalization();
        }

        public ProjectForm(Project project)
        {
            InitializeComponent();
            Initalization(project);
        }

        private void Initalization(Project project = null)
        {
            _service = new BaseRepositoryService<Project>(new BaseRepository<Project>(new SQLiteContext()));
            var executables = (new BaseRepositoryService<Executable>(new BaseRepository<Executable>(new SQLiteContext()))).All();
            CbExecutable.DataSource = executables;
            CbExecutable.DisplayMember = "Name";
            CbExecutable.ValueMember = "Id";
            CbExecutable.SelectedItem = null;

            Text = Resources.Strings.Insert + " " +  Resources.Strings.Project;
            LblName.Text = Resources.Strings.Name.Trim();
            LblPath.Text = Resources.Strings.Path.Trim();
            LblExecutable.Text = Resources.Strings.Executable.Trim();
            LblExecutableArgs.Text = Resources.Strings.ExecutableArgs.Trim();
            BtnSave.Text = Resources.Strings.Save.Trim();

            if (project != null)
            {
                LoadProject(project);
            }
            else
            {
                Project = new();
            }
        }

        private void BtnFileBrowseDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = FBDPath.ShowDialog();

            if (result == DialogResult.OK)
            {
                TbPath.Text = FBDPath.SelectedPath;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Project.Id > 0)
                {
                    bool isRunning = ProjectRunnerService.IsRunning(Project.Id);

                    if (isRunning)
                    {
                        throw new Exception(Resources.Strings.DenyActionWhenProjectRunning);
                    }
                }

                Project.Name = TbName.Text.Trim();
                Project.Path = TbPath.Text.Trim();
                Project.ExecutableId = Convert.ToInt32(CbExecutable.SelectedValue);
                Project.ExecutableArguments = TbExecutableArgs.Text.Trim();
                _service.Save<ProjectValidator>(Project);
                Project = _service.Find(Project.Id, project => project.Include(p => p.Executable));

                if (Project == null)
                {
                    throw new Exception(Resources.Strings.ProjectSaveError);
                }

                MessageBox.Show(Resources.Strings.ProjectSaveSuccess);                
                
                OnProjectSaved(Project);                
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show(Utils.HandleExceptionMessage(ex));
            } 
        }

        private void LoadProject(Project project)
        {
            Project = project;

            TbName.Text = Project.Name;
            TbPath.Text = Project.Path;
            FBDPath.SelectedPath = Project.Path;
            CbExecutable.SelectedValue = Project.ExecutableId;
            TbExecutableArgs.Text = Project.ExecutableArguments;
        }
    }
}
