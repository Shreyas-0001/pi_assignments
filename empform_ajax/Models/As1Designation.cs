using System;
using System.Collections.Generic;

namespace empform_ajax.Models;

public partial class As1Designation
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<As1Employee> As1Employees { get; } = new List<As1Employee>();
}
