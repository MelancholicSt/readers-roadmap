using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public class TaskStatus : IEntity
{
    public long Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<RoadmapTask> RoadmapTasks { get; set; } = new List<RoadmapTask>();
}
