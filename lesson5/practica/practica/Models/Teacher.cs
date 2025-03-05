using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? IdDepartment { get; set; }

    public virtual Department? IdDepartmentNavigation { get; set; }

    public virtual ICollection<TCard> TCards { get; set; } = new List<TCard>();
}
