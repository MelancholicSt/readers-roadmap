using BookStackRoadmap.Entities;

namespace BookStackRoadmap.Data.Repositories;

public class RoadmapTaskRepository : IRoadmapTaskRepository
{
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public void Save()
    {
        
    }

    public IEnumerable<RoadmapTask> GetAll()
    {
        throw new NotImplementedException();
    }

    public RoadmapTask Get(long id)
    {
        throw new NotImplementedException();
    }

    public void Create(RoadmapTask entity)
    {
        throw new NotImplementedException();
    }

    public void Update(RoadmapTask entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(RoadmapTask entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RoadmapTask> GetCompletedTasks()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RoadmapTask> GetProcessingTasks()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RoadmapTask> GetCreatedTasks()
    {
        throw new NotImplementedException();
    }
}