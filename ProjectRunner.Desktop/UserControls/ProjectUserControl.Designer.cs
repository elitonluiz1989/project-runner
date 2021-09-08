
namespace ProjectRunner.Desktop.UserControls
{
    partial class ProjectUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlButtons = new System.Windows.Forms.Panel();
            this.BtnAction = new System.Windows.Forms.Button();
            this.MSManage = new System.Windows.Forms.MenuStrip();
            this.MSManageItems = new System.Windows.Forms.ToolStripMenuItem();
            this.MSManageEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MSManageRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MSManageShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlDescription = new System.Windows.Forms.Panel();
            this.LblProject = new System.Windows.Forms.Label();
            this.PnlButtons.SuspendLayout();
            this.MSManage.SuspendLayout();
            this.PnlDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlButtons
            // 
            this.PnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlButtons.Controls.Add(this.BtnAction);
            this.PnlButtons.Controls.Add(this.MSManage);
            this.PnlButtons.Location = new System.Drawing.Point(484, 0);
            this.PnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.PnlButtons.Name = "PnlButtons";
            this.PnlButtons.Padding = new System.Windows.Forms.Padding(19, 18, 19, 18);
            this.PnlButtons.Size = new System.Drawing.Size(325, 99);
            this.PnlButtons.TabIndex = 1;
            // 
            // BtnAction
            // 
            this.BtnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAction.Location = new System.Drawing.Point(30, 27);
            this.BtnAction.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAction.Name = "BtnAction";
            this.BtnAction.Size = new System.Drawing.Size(125, 49);
            this.BtnAction.TabIndex = 0;
            this.BtnAction.Text = "Run";
            this.BtnAction.UseVisualStyleBackColor = true;
            this.BtnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // MSManage
            // 
            this.MSManage.AutoSize = false;
            this.MSManage.Dock = System.Windows.Forms.DockStyle.None;
            this.MSManage.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.MSManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSManageItems});
            this.MSManage.Location = new System.Drawing.Point(181, 25);
            this.MSManage.Name = "MSManage";
            this.MSManage.Padding = new System.Windows.Forms.Padding(0);
            this.MSManage.Size = new System.Drawing.Size(138, 49);
            this.MSManage.TabIndex = 1;
            // 
            // MSManageItems
            // 
            this.MSManageItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MSManageEditItem,
            this.MSManageRemoveItem,
            this.MSManageShowLog});
            this.MSManageItems.Name = "MSManageItems";
            this.MSManageItems.Padding = new System.Windows.Forms.Padding(0);
            this.MSManageItems.Size = new System.Drawing.Size(118, 49);
            this.MSManageItems.Text = "Manage";
            // 
            // MSManageEditItem
            // 
            this.MSManageEditItem.Name = "MSManageEditItem";
            this.MSManageEditItem.Size = new System.Drawing.Size(403, 48);
            this.MSManageEditItem.Text = "Edit";
            this.MSManageEditItem.Click += new System.EventHandler(this.MSManageEditItem_Click);
            // 
            // MSManageRemoveItem
            // 
            this.MSManageRemoveItem.Name = "MSManageRemoveItem";
            this.MSManageRemoveItem.Size = new System.Drawing.Size(403, 48);
            this.MSManageRemoveItem.Text = "Remove";
            this.MSManageRemoveItem.Click += new System.EventHandler(this.MSManageRemoveItem_Click);
            // 
            // MSManageShowLog
            // 
            this.MSManageShowLog.Name = "MSManageShowLog";
            this.MSManageShowLog.Size = new System.Drawing.Size(403, 48);
            this.MSManageShowLog.Text = "Log";
            this.MSManageShowLog.Click += new System.EventHandler(this.MSManageShowLog_Click);
            // 
            // PnlDescription
            // 
            this.PnlDescription.Controls.Add(this.LblProject);
            this.PnlDescription.Location = new System.Drawing.Point(0, 0);
            this.PnlDescription.Margin = new System.Windows.Forms.Padding(0);
            this.PnlDescription.Name = "PnlDescription";
            this.PnlDescription.Padding = new System.Windows.Forms.Padding(19, 18, 19, 18);
            this.PnlDescription.Size = new System.Drawing.Size(488, 99);
            this.PnlDescription.TabIndex = 2;
            // 
            // LblProject
            // 
            this.LblProject.Font = new System.Drawing.Font("Segoe UI", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblProject.Location = new System.Drawing.Point(0, 0);
            this.LblProject.Margin = new System.Windows.Forms.Padding(0);
            this.LblProject.Name = "LblProject";
            this.LblProject.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.LblProject.Size = new System.Drawing.Size(484, 99);
            this.LblProject.TabIndex = 0;
            this.LblProject.Text = "Project";
            this.LblProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProjectUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PnlDescription);
            this.Controls.Add(this.PnlButtons);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(812, 99);
            this.Name = "ProjectUserControl";
            this.Size = new System.Drawing.Size(812, 99);
            this.PnlButtons.ResumeLayout(false);
            this.MSManage.ResumeLayout(false);
            this.MSManage.PerformLayout();
            this.PnlDescription.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlButtons;
        private System.Windows.Forms.Button BtnAction;
        private System.Windows.Forms.Panel PnlDescription;
        private System.Windows.Forms.Label LblProject;
        private System.Windows.Forms.MenuStrip MSManage;
        private System.Windows.Forms.ToolStripMenuItem MSManageItems;
        private System.Windows.Forms.ToolStripMenuItem MSManageEditItem;
        private System.Windows.Forms.ToolStripMenuItem MSManageRemoveItem;
        private System.Windows.Forms.ToolStripMenuItem MSManageShowLog;
    }
}
