using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Worktype
    {
        public Worktype()
        {
            Partlists = new HashSet<Partlist>();
            Worklists = new HashSet<Worklist>();
        }

        public int Id { get; set; }
        public string Workname { get; set; } = null!;

        public virtual ICollection<Partlist> Partlists { get; set; }
        public virtual ICollection<Worklist> Worklists { get; set; }
    }
}
