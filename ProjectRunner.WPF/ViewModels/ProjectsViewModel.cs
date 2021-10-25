using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Repository;

namespace ProjectRunner.WPF.ViewModels
{
    public class ProjectsViewModel : RecordsViewModel<Project>
    {
        public ProjectsViewModel(BaseRepository<Project> projectRepository)
            : base(projectRepository)
        {
            GetRecords();
        }
    }
}