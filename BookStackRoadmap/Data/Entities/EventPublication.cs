using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Data.Entities;

public class EventPublication
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CompletionDate { get; set; }

    public string? EventType { get; set; }

    public string? ListenerId { get; set; }

    public DateTime? PublicationDate { get; set; }

    public string? SerializedEvent { get; set; }
}
