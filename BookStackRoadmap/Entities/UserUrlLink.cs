using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public partial class UserUrlLink
{
    public string UserId { get; set; } = null!;

    public long UrlLinkId { get; set; }
}
