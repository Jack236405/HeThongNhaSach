using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HeThongNhaSach.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Sach = new HashSet<Sach>();
        }
        [Required(ErrorMessage = "* Bắt buộc!")]
        public string Manv { get; set; }
        [Required(ErrorMessage = "* Bắt buộc!")]
        public string Matkhau { get; set; }
        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage = "* Bắt buộc!")]
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool? Phai { get; set; }
        public int? Macv { get; set; }
        public double? Phucap { get; set; }
        public double? Luong { get; set; }

        public virtual Chucvu MacvNavigation { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
