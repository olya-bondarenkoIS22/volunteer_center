using System;
using System.Collections.Generic;

namespace Volunteer_Center.models;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
