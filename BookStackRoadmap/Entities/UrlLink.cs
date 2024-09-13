using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public partial class UrlLink
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string Url { get; set; } = null!;
}
