using System;
using System.Collections.Generic;

namespace practica.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdDepartment { get; set; }

    public virtual Department IdDepartmentNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
