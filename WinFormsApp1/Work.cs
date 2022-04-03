using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Work
    {
        public Work()
        {
            Commitions = new HashSet<Commition>();
        }

        public int Id { get; set; }
        public int Partlistid { get; set; }
        public int Carid { get; set; }
        public int Worklistid { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Partlist Partlist { get; set; } = null!;
        public virtual Worklist Worklist { get; set; } = null!;
        public virtual ICollection<Commition> Commitions { get; set; }
    }
}
