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
<<<<<<< HEAD
        public string Diachi { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool? Phai { get; set; }
        public int? Macv { get; set; }
        public double? Phucap { get; set; }
        public double? Luong { get; set; }

=======
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Giới tính")]
        public bool? Phai { get; set; }
        [Display(Name = "Chức vụ")]
        public int? Macv { get; set; }
        [Display(Name = "Phụ cấp")]
        public double? Phucap { get; set; }
        [Display(Name = "Lương")]
        public double? Luong { get; set; }
        [Display(Name = "Chức vụ")]
>>>>>>> a445a4153798aa13716d281869a69d9754782e61
        public virtual Chucvu MacvNavigation { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
