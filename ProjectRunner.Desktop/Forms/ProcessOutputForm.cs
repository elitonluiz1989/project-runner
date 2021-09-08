using System;
using System.Windows.Forms;

namespace ProjectRunner.Desktop.Forms
{
    public delegate void OnShowTerminal(EventArgs e);
    public delegate void OnCloseTerminal(FormClosingEventArgs e);

    public partial class ProcessOutputForm : Form
    {
        public OnShowTerminal OnShowTerminal { get; set; }
        public OnCloseTerminal OnCloseTerminal { get; set; }
        private string _message;

        public ProcessOutputForm()
        {
            InitializeComponent();
            Text = Resources.Strings.ProcessOutput;
        }

        protected override void OnShown(EventArgs e)
        {
            OnShowTerminal(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            OnCloseTerminal(e);
        }

        public void PrintOutput(string message = null)
        {
            _message += message + Environment.NewLine;
            SetMessage();
        }

        public void ClearOutput()
        {
            _message = string.Empty;
            SetMessage();
        }

        private void SetMessage()
        {
            lblOutput.Text = _message;
        }
    }
}
