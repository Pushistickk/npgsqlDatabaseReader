using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Car
    {
        public Car()
        {
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }
        public string Carname { get; set; } = null!;

        public virtual ICollection<Work> Works { get; set; }
    }
}
