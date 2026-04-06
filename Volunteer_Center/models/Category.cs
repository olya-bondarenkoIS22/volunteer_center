using System;
using System.Collections.Generic;

namespace Volunteer_Center.models;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
