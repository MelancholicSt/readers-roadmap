using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Data.Entities;

public class BookStatus
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public virtual Book? Book { get; set; }
}
