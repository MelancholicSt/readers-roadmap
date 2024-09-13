using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public partial class File
{
    public long Id { get; set; }

    public string Path { get; set; } = null!;

    public long BookPageId { get; set; }

    public virtual BookPage BookPage { get; set; } = null!;

    public virtual ICollection<BookPage> BookPages { get; set; } = new List<BookPage>();
}
