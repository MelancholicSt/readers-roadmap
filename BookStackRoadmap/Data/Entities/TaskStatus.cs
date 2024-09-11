using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Data.Entities;

public partial class TaskStatus
{
    public long Id { get; set; }

    public string StatusName { get; set; } = null!;

    public long? TaskId { get; set; }

    public virtual Task? Task { get; set; }
}
