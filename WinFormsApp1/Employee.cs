using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Employee
    {
        public Employee()
        {
            Commitions = new HashSet<Commition>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public int Passports { get; set; }
        public int Passportn { get; set; }
        public int Posid { get; set; }

        public virtual Position Pos { get; set; } = null!;
        public virtual ICollection<Commition> Commitions { get; set; }
    }
}
