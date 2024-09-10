using BookStackRoadmap.Context;
using TaskStatus = BookStackRoadmap.Entities.TaskStatus;

namespace BookStackRoadmap.Data.Repositories;

public class TaskStatusRepository(RoadmapContext context) : ITaskStatusRepository
{
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public void Save()
    {
        context.SaveChanges();
    }

    public IEnumerable<TaskStatus> GetAll()
    {
        return context.TaskStatuses.AsEnumerable();
    }

    public TaskStatus? Get(long id)
    {
        return context.TaskStatuses.Find(id);
    }

    public void Create(TaskStatus entity)
    {
        context.TaskStatuses.Add(entity);
        Save();
    }

    public void Update(TaskStatus entity)
    {
        TaskStatus status = context.TaskStatuses.Find(entity.Id);
        context.Entry(status).CurrentValues.SetValues(entity);
        Save();
    }

    public void Remove(TaskStatus entity)
    {
        TaskStatus status = context.TaskStatuses.Find(entity.Id);
        context.TaskStatuses.Remove(status);
    }
}