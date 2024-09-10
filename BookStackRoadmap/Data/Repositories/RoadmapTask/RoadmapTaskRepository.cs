using BookStackRoadmap.Context;
using BookStackRoadmap.Entities;
using Microsoft.EntityFrameworkCore;
using TaskStatus = BookStackRoadmap.Entities.TaskStatus;

namespace BookStackRoadmap.Data.Repositories;

public class RoadmapTaskRepository(RoadmapContext context) : IRoadmapTaskRepository
{
    public void Dispose()
    {
        // TODO release managed resources here
    }

    public void Save()
    {
        context.SaveChanges(true);
    }

    public IEnumerable<RoadmapTask> GetAll()
    {
        return context.RoadmapTasks.AsEnumerable();
    }

    public RoadmapTask? Get(long id)
    {
        return context.RoadmapTasks.Find(id);
    }

    public void Create(RoadmapTask entity)
    {
        context.RoadmapTasks.Add(entity);
        Save();
    }

    public void Update(RoadmapTask entity)
    {
        RoadmapTask task = context.RoadmapTasks.Find(entity.Id);
        context.Entry(task).CurrentValues.SetValues(entity);
        Save();
    }

    public void Remove(RoadmapTask entity)
    {
        context.RoadmapTasks.Remove(entity);
        Save();
    }

    public IEnumerable<RoadmapTask> GetCompletedTasks()
    {
        IEnumerable<RoadmapTask> completedTasks = context.RoadmapTasks
            .Include(c => c.Status)
            .Where(c => c.Status.StatusName == "done");
        return completedTasks;
    }

    public IEnumerable<RoadmapTask> GetTasksInProgress()
    {
        IEnumerable<RoadmapTask> tasksInProgress = context.RoadmapTasks
            .Include(c => c.Status)
            .Where(c => c.Status.StatusName == "reading");
        return tasksInProgress;
    }

    public IEnumerable<RoadmapTask> GetCreatedTasks()
    {
        IEnumerable<RoadmapTask> createdTasks = context.RoadmapTasks
            .Include(c => c.Status)
            .Where(c => c.Status.StatusName == "created");
        return createdTasks;
    }
}