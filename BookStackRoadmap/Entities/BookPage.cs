using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public partial class BookPage
{
    public long Id { get; set; }

    public int PageNumber { get; set; }

    public long FileId { get; set; }

    public long BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual File File { get; set; } = null!;

    public virtual File? FileNavigation { get; set; }
}
