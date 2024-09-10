using BookStackRoadmap.Entities;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace BookStackRoadmap.Services;

public interface ITaskService
{
    void CreateTask(Book book, string name, string description);
    void CompleteTask(int taskId);
    void DenyTask(int taskId);
    
    ICollection<RoadmapTask> GetCreatedTasks();
    ICollection<RoadmapTask> GetTasksInProgress();
    ICollection<RoadmapTask> GetCompletedTasks();
}