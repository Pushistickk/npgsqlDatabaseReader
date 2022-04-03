using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Posname { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
