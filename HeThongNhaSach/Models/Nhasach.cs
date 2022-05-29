using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class Nhasach
    {
        public Nhasach()
        {
            Sachnhasach = new HashSet<Sachnhasach>();
        }

        public int Mans { get; set; }
        public string Tenns { get; set; }
        public string Diachi { get; set; }
        public string Std { get; set; }

        public virtual ICollection<Sachnhasach> Sachnhasach { get; set; }
    }
}
