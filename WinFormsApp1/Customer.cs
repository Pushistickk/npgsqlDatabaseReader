using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Customer
    {
        public Customer()
        {
            Commitions = new HashSet<Commition>();
        }

        public int Id { get; set; }
        public string Customername { get; set; } = null!;

        public virtual ICollection<Commition> Commitions { get; set; }
    }
}
