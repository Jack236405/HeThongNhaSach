using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class Sachnhasach
    {
        public int Mans { get; set; }
        public int Masach { get; set; }
        public int? Soluong { get; set; }
        public double? Dongia { get; set; }
        public double? Chietkhau { get; set; }


        public virtual Nhasach MansNavigation { get; set; }
        public virtual Sach MasachNavigation { get; set; }
    }
}
