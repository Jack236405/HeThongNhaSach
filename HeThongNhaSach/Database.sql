CREATE DATABASE #HeThongNhaSach
USE #HeThongNhaSach
GO

CREATE TABLE CHUCVU(
	Macv INT IDENTITY PRIMARY KEY,
	Tencv NVARCHAR(250) NULL,
	Taikhoan nchar(100) NULL,
	Matkhau char(40) NULL,
)

CREATE TABLE NHANVIEN(
	Manv NVARCHAR(5) PRIMARY KEY,
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

CREATE TABLE SACHNHASACH(
	Mans INT FOREIGN KEY(Mans) REFERENCES dbo.NHASACH(Mans) NOT NULL,
	Masach INT FOREIGN KEY(Masach) REFERENCES dbo.SACH(Masach) NOT NULL,
	Soluong INT NULL,
	Dongia FLOAT NULL,
	Chietkhau FLOAT NULL
	PRIMARY KEY(Mans, Masach)
)