using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using System.Diagnostics;

namespace ProjectRunner.Common.Dto
{
    public class ProjectRunnerDto
    {
        public Project Project { get; set; }
        public IProcessOutputService ProcessOutputService { get; set; }
        public Process Process { get; set; }
        public bool IsRunning { get; set; }
    }
}
