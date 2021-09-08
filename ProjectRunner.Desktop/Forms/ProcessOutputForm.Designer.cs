
namespace ProjectRunner.Desktop.Forms
{
    partial class ProcessOutputForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessOutputForm));
            this.lblOutput = new System.Windows.Forms.Label();
            this.PnlOutput = new System.Windows.Forms.Panel();
            this.PnlOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.BackColor = System.Drawing.Color.Transparent;
            this.lblOutput.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOutput.Location = new System.Drawing.Point(0, 0);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 37);
            this.lblOutput.TabIndex = 0;
            // 
            // PnlOutput
            // 
            this.PnlOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PnlOutput.Controls.Add(this.lblOutput);
            this.PnlOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlOutput.Location = new System.Drawing.Point(0, 0);
            this.PnlOutput.Name = "PnlOutput";
            this.PnlOutput.Size = new System.Drawing.Size(772, 521);
            this.PnlOutput.TabIndex = 1;
            // 
            // ProcessOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 521);
            this.Controls.Add(this.PnlOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessOutputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Process Output";
            this.PnlOutput.ResumeLayout(false);
            this.PnlOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Panel PnlOutput;
    }
}