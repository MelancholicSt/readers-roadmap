using System;
using System.Collections.Generic;

namespace BookStackRoadmap.Entities;

public partial class User
{
    public string Id { get; set; } = null!;

    public string AuthHash { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public ulong? IsVerified { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<UrlLink> UrlLinks { get; set; } = new List<UrlLink>();
}
