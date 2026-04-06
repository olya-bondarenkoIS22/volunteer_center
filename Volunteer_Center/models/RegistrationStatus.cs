using System;
using System.Collections.Generic;

namespace Volunteer_Center.models;

public partial class RegistrationStatus
{
    public int Id { get; set; }

    public string? RegistrationStatusName { get; set; }

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
