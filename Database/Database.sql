--CREATE DATABASE #HeThongNhaSach
USE #HeThongNhaSach
GO

CREATE TABLE CHUCVU(
	Macv INT IDENTITY PRIMARY KEY,
	Tencv NVARCHAR(250) NULL,
	Taikhoan nchar(100) NULL,
	Matkhau char(40) NULL,
)

CREATE TABLE NHANVIEN(
	Manv NVARCHAR(7) PRIMARY KEY,
	Matkhau VARCHAR(40) NOT NULL,
	Hoten NVARCHAR(250) NULL,
	Diachi NVARCHAR(250) NULL,
	Ngaysinh DATE NULL,
	Phai BIT NULL,
	Macv INT FOREIGN KEY(Macv) REFERENCES dbo.CHUCVU(Macv),
	Phucap FLOAT NULL,
	Luong FLOAT NULL,
)

CREATE TABLE LOAISACH(
	Maloai INT IDENTITY PRIMARY KEY,
	Tenloai NVARCHAR(250) NULL
)

CREATE TABLE NHAXUATBAN(
	Manxb INT IDENTITY PRIMARY KEY,
	Tennxb NVARCHAR(250) NULL,
	Diachi NVARCHAR(250) NULL,
	Sdt NVARCHAR(11) NULL
)

CREATE TABLE SACH(
	Masach INT IDENTITY PRIMARY KEY,
	Tensach NVARCHAR(250) NULL,
	Tacgia NVARCHAR(250) NULL,
	Isbn NVARCHAR(250) NULL,
	Maloai INT FOREIGN KEY(Maloai) REFERENCES dbo.LOAISACH(Maloai) NULL,
	Manv NVARCHAR(5) FOREIGN KEY(Manv) REFERENCES dbo.NHANVIEN(Manv) NULL,
	Manxb INT FOREIGN KEY(Manxb) REFERENCES dbo.NHAXUATBAN(Manxb) NULL,
	Dongia FLOAT NULL,
	Soluong INT NULL,
	Chietkhau FLOAT NULL,
	Ghichu NVARCHAR(MAX) NULL,
)


CREATE TABLE HOADON(
	Mahd INT IDENTITY PRIMARY KEY,
	Loaihd INT NULL,
	Ngaylap DATE NULL,
	Manv NVARCHAR(5) NULL,
	Tinhtrang INT NULL,
)

CREATE TABLE CHITIETHD(
	Mahd INT FOREIGN KEY(Mahd) REFERENCES dbo.HOADON(Mahd) NOT NULL,
	Masach INT FOREIGN KEY(Masach) REFERENCES dbo.SACH(Masach) NOT NULL,
	Soluong INT NULL,
	Dongia FLOAT NULL,
	PRIMARY KEY(Mahd, Masach)
)

CREATE TABLE NHASACH(
	Mans INT IDENTITY PRIMARY KEY,
	Tenns NVARCHAR(250) NOT NULL,
	Diachi NVARCHAR(250) NOT NULL,
	Std VARCHAR(11) NULL,
)

CREATE TABLE PHANPHOISACH(
	Mapp INT IDENTITY,
	Mans INT FOREIGN KEY(Mans) REFERENCES dbo.NHASACH(Mans) NOT NULL,
	Masach INT FOREIGN KEY(Masach) REFERENCES dbo.SACH(Masach) NOT NULL,
	Soluong INT NULL,
	Dongia FLOAT NULL,
	Chietkhau FLOAT NULL
	PRIMARY KEY(Mapp)
)


select * from CHUCVU
INSERT [dbo].[CHUCVU] ([Macv],[Tencv],[TaiKhoan],[MatKhau]) VALUES (1, N'Bộ Phận Điều Hành', 'BPDH_1','40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv],[Tencv],[TaiKhoan],[MatKhau]) VALUES (2,  N'Nhân Viên Quản lý', 'NVQL_1','40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv],[Tencv],[TaiKhoan],[MatKhau]) VALUES (3, N'Quản Lý Nhập Hàng', 'QLNH_1','40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv],[Tencv],[TaiKhoan],[MatKhau]) VALUES (4, N'Quản Lý Nhân Sự', 'QLNS_1','40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv],[Tencv],[TaiKhoan],[MatKhau]) VALUES (5, N'Nhân Viên Bán Hàng', 'NVBH_1','40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv],[Tencv],[TaiKhoan],[MatKhau]) VALUES (6, N'Kế Toán Bán Hàng', 'KTBH_1','40bd001563085fc35165329ea1ff5c5ecbdbbeef')

select * from NHANVIEN

INSERT [dbo].[NHANVIEN] ([Manv],[Matkhau],[Hoten],[Diachi],[Ngaysinh],[Phai],[Macv],[Phucap],[Luong]) VALUES ('NV01', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Phan Hồ Cước','AG','2022-05-14',1,7,null,50000000)
INSERT [dbo].[NHANVIEN] ([Manv],[Matkhau],[Hoten],[Diachi],[Ngaysinh],[Phai],[Macv],[Phucap],[Luong]) VALUES ('NV02', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Nguyễn Tấn Phát','AG','2022-05-14',1,7,null,30000000)
INSERT [dbo].[NHANVIEN] ([Manv],[Matkhau],[Hoten],[Diachi],[Ngaysinh],[Phai],[Macv],[Phucap],[Luong]) VALUES ('NV03', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Thạch Phúc Vinh','AG','2022-05-14',1,7,null,20000000)
INSERT [dbo].[NHANVIEN] ([Manv],[Matkhau],[Hoten],[Diachi],[Ngaysinh],[Phai],[Macv],[Phucap],[Luong]) VALUES ('NV04', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Dương Trọng Phát','AG','2022-05-14',1,7,null,20000000)
INSERT [dbo].[NHANVIEN] ([Manv],[Matkhau],[Hoten],[Diachi],[Ngaysinh],[Phai],[Macv],[Phucap],[Luong]) VALUES ('NV05', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Dương Huỳnh Phúc Hậu','AG','2022-05-14',1,7,null,20000000)
INSERT [dbo].[NHANVIEN] ([Manv],[Matkhau],[Hoten],[Diachi],[Ngaysinh],[Phai],[Macv],[Phucap],[Luong]) VALUES ('NV06', '40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Cao Hoàng Minh','AG','2022-05-14',1,7,null,20000000)