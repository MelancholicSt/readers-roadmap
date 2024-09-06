using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public class RoadmapTask : IEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public long BookId { get; set; }

    public long? StatusId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual TaskStatus? Status { get; set; }
}
