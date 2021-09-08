using ProjectRunner.Common.Contracts;
using ProjectRunner.Desktop.Forms;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectRunner.Desktop.Services
{
    public class TerminalOutputService : IProcessOutputService
    {
        private readonly TerminalForm _teminalForm;
        private delegate void TerminalOutputDelegate(string message = null);

        public TerminalOutputService()
        {
            _teminalForm = new();
        }

        public void Add(string message = null)
        {
            _teminalForm.PrintOutput(message);
        }

        public void Add(object process, DataReceivedEventArgs eventArgs)
        {
            _teminalForm.Invoke(new TerminalOutputDelegate(_teminalForm.PrintOutput), eventArgs.Data);
        }

        public void Clear()
        {
            _teminalForm.ClearOutput();
        }

        public void Show()
        {
            _teminalForm.ShowDialog();
        }

        public void SetBeginOutputHandler(BeginOutputReadLine handler, int processIndex)
        {
            _teminalForm.OnShowTerminal = (EventArgs e) => handler(processIndex);
        }

        public void SetCancelOutputHandler(CancelOutputRead handler, int processIndex)
        {
            _teminalForm.OnCloseTerminal = (FormClosingEventArgs e) => handler(processIndex);
        }
    }
}
