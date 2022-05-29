using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class Chucvu
    {
        public Chucvu()
        {
            Nhanvien = new HashSet<Nhanvien>();
        }

        public int Macv { get; set; }
        public string Tencv { get; set; }
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }

        public virtual ICollection<Nhanvien> Nhanvien { get; set; }
    }
}
