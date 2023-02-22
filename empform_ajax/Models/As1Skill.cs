using System;
using System.Collections.Generic;

namespace empform_ajax.Models;

public partial class As1Skill
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<As1Employee> Emps { get; set; } = new List<As1Employee>();
}
