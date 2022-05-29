using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class Nhaxuatban
    {
        public Nhaxuatban()
        {
            Sach = new HashSet<Sach>();
        }

        public int Manxb { get; set; }
        public string Tennxb { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
