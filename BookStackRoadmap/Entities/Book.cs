using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public partial class Book
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public virtual ICollection<BookPage> BookPages { get; set; } = new List<BookPage>();
}
