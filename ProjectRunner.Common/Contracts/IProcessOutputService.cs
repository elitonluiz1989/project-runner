using System.Diagnostics;

namespace ProjectRunner.Common.Contracts
{
    public delegate void BeginOutputReadLine(int index);

    public delegate void CancelOutputRead(int index);

    public interface IProcessOutputService
    {
        public void Add(string message);
        public void Add(object process, DataReceivedEventArgs eventArgs);
        public void Clear();
        public void Show();
        public void SetBeginOutputHandler(BeginOutputReadLine handler, int processIndex);
        public void SetCancelOutputHandler(CancelOutputRead handler, int processIndex);
    }
}
