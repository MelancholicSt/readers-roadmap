using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Data.Entities;

public partial class Task
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TaskStatus> TaskStatuses { get; set; } = new List<TaskStatus>();
}
