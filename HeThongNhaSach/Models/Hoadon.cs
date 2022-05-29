using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethd = new HashSet<Chitiethd>();
        }

        public int Mahd { get; set; }
        public int? Loaihd { get; set; }
        public DateTime? Ngaylap { get; set; }
        public string Manv { get; set; }
        public int? Tinhtrang { get; set; }

        public virtual ICollection<Chitiethd> Chitiethd { get; set; }
    }
}
