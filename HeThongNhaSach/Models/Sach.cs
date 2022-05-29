using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class Sach
    {
        public Sach()
        {
            Chitiethd = new HashSet<Chitiethd>();
            Sachnhasach = new HashSet<Sachnhasach>();
        }

        public int Masach { get; set; }
        public string Tensach { get; set; }
        public string Tacgia { get; set; }
        public string Isbn { get; set; }
        public int? Maloai { get; set; }
        public string Manv { get; set; }
        public int? Manxb { get; set; }
        public double? Dongia { get; set; }
        public int? Soluong { get; set; }
        public double? Chietkhau { get; set; }
        public string Ghichu { get; set; }

        public virtual Loaisach MaloaiNavigation { get; set; }
        public virtual Nhanvien ManvNavigation { get; set; }
        public virtual Nhaxuatban ManxbNavigation { get; set; }
        public virtual ICollection<Chitiethd> Chitiethd { get; set; }
        public virtual ICollection<Sachnhasach> Sachnhasach { get; set; }
    }
}
