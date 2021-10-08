using ProjectRunner.Common.Contracts;
using ProjectRunner.Common.Entities;
using ProjectRunner.Infra.Data.Context;

namespace ProjectRunner.Infra.Data.Repository
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(SQLiteContext dbContext) : base(dbContext)
        { }
    }
}
