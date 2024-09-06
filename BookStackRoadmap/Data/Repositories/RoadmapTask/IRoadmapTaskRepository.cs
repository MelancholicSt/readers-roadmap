using BookStackRoadmap.Entities;

namespace BookStackRoadmap.Data.Repositories;

public interface IRoadmapTaskRepository : ICrudRepository<RoadmapTask, long>, IDisposable
{
    IEnumerable<RoadmapTask> GetCompletedTasks();
    IEnumerable<RoadmapTask> GetProcessingTasks();
    IEnumerable<RoadmapTask> GetCreatedTasks();
    
}