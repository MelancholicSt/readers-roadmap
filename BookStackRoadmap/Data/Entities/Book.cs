using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public class Book : IEntity
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public virtual ICollection<RoadmapTask> RoadmapTasks { get; set; } = new List<RoadmapTask>();
}
