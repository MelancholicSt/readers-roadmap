using TaskStatus = BookStackRoadmap.Entities.TaskStatus;

namespace BookStackRoadmap.Data.Repositories;

public interface ITaskStatusRepository : ICrudRepository<TaskStatus, long>, IDisposable
{
    
}