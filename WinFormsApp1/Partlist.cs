using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Partlist
    {
        public Partlist()
        {
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }
        public int Partlistid { get; set; }
        public string Partname { get; set; } = null!;
        public int Worktypeid { get; set; }

        public virtual Worktype Worktype { get; set; } = null!;
        public virtual ICollection<Work> Works { get; set; }
    }
}
