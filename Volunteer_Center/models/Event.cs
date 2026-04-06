using System;
using System.Collections.Generic;

namespace Volunteer_Center.models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int IdCategory { get; set; }

    public DateOnly? Date { get; set; }

    public string? Place { get; set; }

    public int? VolunteersNeeded { get; set; }

    public int IdStatus { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
