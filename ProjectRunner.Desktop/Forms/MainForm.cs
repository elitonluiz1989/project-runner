﻿using ProjectRunner.Desktop.UserControls;
using ProjectRunner.Entities;
using ProjectRunner.Infra.Data.Context;
using ProjectRunner.Infra.Data.Repository;
using ProjectRunner.Services;
using System;
using System.Windows.Forms;

namespace ProjectRunner.Desktop.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            LoadProjects();
        }

        private void BtnAddProject_Click(object sender, System.EventArgs e)
        {
            Form projectForm = new ProjectForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            projectForm.ShowDialog();
        }

        private void LoadProjects()
        {
            var service = new BaseService<Project>(new BaseRepository<Project>(new SQLiteContext()));
            var projects = service.All();

            foreach (var project in projects)
            {
                UCProject ucProject = new UCProject(project);
                ucProject.BorderStyle = BorderStyle.FixedSingle;
                ucProject.Margin = new()
                {
                    Left = (int)Math.Floor(((decimal)(FlPProjects.Width - ucProject.Width) / 2)),
                    Top = 16
                };
                FlPProjects.Controls.Add(ucProject);
            }
        }
    }
}
 