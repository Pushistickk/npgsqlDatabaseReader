using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Worklist
    {
        public Worklist()
        {
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }
        public int Worklistid { get; set; }
        public int Cost { get; set; }
        public string Workname { get; set; } = null!;
        public int Worktypeid { get; set; }

        public virtual Worktype Worktype { get; set; } = null!;
        public virtual ICollection<Work> Works { get; set; }
    }
}
