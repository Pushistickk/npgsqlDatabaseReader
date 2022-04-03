using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Commition
    {
        public int Id { get; set; }
        public int Workid { get; set; }
        public int Employeeid { get; set; }
        public int Customerid { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Work Work { get; set; } = null!;
    }
}
