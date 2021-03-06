USE [master]
GO
/****** Object:  Database [#HeThongNhaSach]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE DATABASE [#HeThongNhaSach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'#HeThongNhaSach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\#HeThongNhaSach.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'#HeThongNhaSach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\#HeThongNhaSach_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [#HeThongNhaSach] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [#HeThongNhaSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [#HeThongNhaSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [#HeThongNhaSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [#HeThongNhaSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [#HeThongNhaSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET  ENABLE_BROKER 
GO
ALTER DATABASE [#HeThongNhaSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [#HeThongNhaSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [#HeThongNhaSach] SET  MULTI_USER 
GO
ALTER DATABASE [#HeThongNhaSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [#HeThongNhaSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [#HeThongNhaSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [#HeThongNhaSach] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [#HeThongNhaSach] SET DELAYED_DURABILITY = DISABLED 
GO
USE [#HeThongNhaSach]
GO
/****** Object:  User [NV03]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE USER [NV03] FOR LOGIN [QLNH_1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [NV02]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE USER [NV02] FOR LOGIN [NVQL_1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [NV01]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE USER [NV01] FOR LOGIN [BPDH_1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [QLNS]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE ROLE [QLNS]
GO
/****** Object:  DatabaseRole [QLNH]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE ROLE [QLNH]
GO
/****** Object:  DatabaseRole [NVQL]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE ROLE [NVQL]
GO
/****** Object:  DatabaseRole [NVBH]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE ROLE [NVBH]
GO
/****** Object:  DatabaseRole [KTBH]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE ROLE [KTBH]
GO
/****** Object:  DatabaseRole [BPDH]    Script Date: 5/29/2022 4:33:33 PM ******/
CREATE ROLE [BPDH]
GO
ALTER ROLE [QLNH] ADD MEMBER [NV03]
GO
ALTER ROLE [NVQL] ADD MEMBER [NV02]
GO
ALTER ROLE [BPDH] ADD MEMBER [NV01]
GO
/****** Object:  Table [dbo].[CHITIETHD]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHD](
	[Mahd] [int] NOT NULL,
	[Masach] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC,
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[Macv] [int] IDENTITY(1,1) NOT NULL,
	[Tencv] [nvarchar](250) NULL,
	[Taikhoan] [nchar](100) NULL,
	[Matkhau] [char](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[Macv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[Mahd] [int] IDENTITY(1,1) NOT NULL,
	[Loaihd] [int] NULL,
	[Ngaylap] [date] NULL,
	[Manv] [nvarchar](5) NULL,
	[Tinhtrang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAISACH]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISACH](
	[Maloai] [int] IDENTITY(1,1) NOT NULL,
	[Tenloai] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[Manv] [nvarchar](5) NOT NULL,
	[Matkhau] [varchar](40) NOT NULL,
	[Hoten] [nvarchar](250) NULL,
	[Diachi] [nvarchar](250) NULL,
	[Ngaysinh] [date] NULL,
	[Phai] [bit] NULL,
	[Macv] [int] NULL,
	[Phucap] [float] NULL,
	[Luong] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHASACH]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHASACH](
	[Mans] [int] IDENTITY(1,1) NOT NULL,
	[Tenns] [nvarchar](250) NOT NULL,
	[Diachi] [nvarchar](250) NOT NULL,
	[Std] [varchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[Mans] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHAXUATBAN]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAXUATBAN](
	[Manxb] [int] IDENTITY(1,1) NOT NULL,
	[Tennxb] [nvarchar](250) NULL,
	[Diachi] [nvarchar](250) NULL,
	[Sdt] [nvarchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[Manxb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SACH]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[Masach] [int] IDENTITY(1,1) NOT NULL,
	[Tensach] [nvarchar](250) NULL,
	[Tacgia] [nvarchar](250) NULL,
	[Isbn] [nvarchar](250) NULL,
	[Maloai] [int] NULL,
	[Manv] [nvarchar](5) NULL,
	[Manxb] [int] NULL,
	[Dongia] [float] NULL,
	[Soluong] [int] NULL,
	[Chietkhau] [float] NULL,
	[Ghichu] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SACHNHASACH]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACHNHASACH](
	[Mans] [int] NOT NULL,
	[Masach] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Chietkhau] [float] NULL,
	[Dongia] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Mans] ASC,
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[FN_NHANVIEN_ROW]    Script Date: 5/29/2022 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FN_NHANVIEN_ROW](@MANV AS sysname)  
    RETURNS TABLE  
WITH SCHEMABINDING  
AS  
    RETURN SELECT 1 AS FN_NHANVIEN_ROW_RESULT
WHERE @MANV = USER_NAME() OR
	IS_MEMBER('BPDH') = 1 OR 
	IS_MEMBER('QLNS') = 1 OR 
	IS_ROLEMEMBER('db_owner') = 1 OR 
	IS_SRVROLEMEMBER('sysadmin') = 1;

GO
INSERT [dbo].[CHITIETHD] ([Mahd], [Masach], [Soluong], [Dongia]) VALUES (1, 1, 10, 50000)
SET IDENTITY_INSERT [dbo].[CHUCVU] ON 

INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (1, N'Bộ phận điều hành', N'BPDH_2                                                                                              ', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (2, N'Nhân viên quản lý', N'NVQL_1                                                                                              ', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (3, N'Quản lý nhập hàng', N'QLNH_1                                                                                              ', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (4, N'Quản lý nhân sự', NULL, NULL)
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (5, N'Nhân viên bán hàng', NULL, NULL)
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (6, N'Kế toán bán hàng', NULL, NULL)
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (18, N'1', N'11                                                                                                  ', N'1      2                                ')
SET IDENTITY_INSERT [dbo].[CHUCVU] OFF
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([Mahd], [Loaihd], [Ngaylap], [Manv], [Tinhtrang]) VALUES (1, 1, CAST(N'2022-05-29' AS Date), N'NV04', 1)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
SET IDENTITY_INSERT [dbo].[LOAISACH] ON 

INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (1, N'Chính trị – pháp luật')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (2, N'Khoa học công nghệ – Kinh tế')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (3, N'Văn học nghệ thuật')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (4, N'Truyện, tiểu thuyết')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (5, N'1')
SET IDENTITY_INSERT [dbo].[LOAISACH] OFF
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV01', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Nguyễn Văn A', N'F2 Cần Thơ', NULL, 1, 1, 1, 6.5)
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV02', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Nguyễn Văn B', N'F1 Cần Thơ', NULL, 1, 2, 1, 7)
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV03', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Nguyễn Văn C', N'729. F22', CAST(N'2022-05-13' AS Date), 1, 2, NULL, NULL)
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV04', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'04', N'04', CAST(N'2022-05-19' AS Date), 1, 3, 1, 1)
SET IDENTITY_INSERT [dbo].[NHASACH] ON 

INSERT [dbo].[NHASACH] ([Mans], [Tenns], [Diachi], [Std]) VALUES (1, N'Sách Mới', N'Long Xuyên', NULL)
SET IDENTITY_INSERT [dbo].[NHASACH] OFF
SET IDENTITY_INSERT [dbo].[NHAXUATBAN] ON 

INSERT [dbo].[NHAXUATBAN] ([Manxb], [Tennxb], [Diachi], [Sdt]) VALUES (1, N' Nhà xuất bản Chính trị Quốc gia', NULL, NULL)
INSERT [dbo].[NHAXUATBAN] ([Manxb], [Tennxb], [Diachi], [Sdt]) VALUES (2, N'Nhà xuất bản Hà Nội', NULL, NULL)
INSERT [dbo].[NHAXUATBAN] ([Manxb], [Tennxb], [Diachi], [Sdt]) VALUES (3, N' Nhà xuất bản Đồng Nai', NULL, NULL)
INSERT [dbo].[NHAXUATBAN] ([Manxb], [Tennxb], [Diachi], [Sdt]) VALUES (4, N'Nhà xuất bản Giáo dục', NULL, NULL)
INSERT [dbo].[NHAXUATBAN] ([Manxb], [Tennxb], [Diachi], [Sdt]) VALUES (5, N'2', N'2', N'2')
SET IDENTITY_INSERT [dbo].[NHAXUATBAN] OFF
SET IDENTITY_INSERT [dbo].[SACH] ON 

INSERT [dbo].[SACH] ([Masach], [Tensach], [Tacgia], [Isbn], [Maloai], [Manv], [Manxb], [Dongia], [Soluong], [Chietkhau], [Ghichu]) VALUES (1, N'2 ten sach', N'2', NULL, 1, N'NV01', 1, 10, 10, 1, NULL)
SET IDENTITY_INSERT [dbo].[SACH] OFF
INSERT [dbo].[SACHNHASACH] ([Mans], [Masach], [Soluong], [Chietkhau], [Dongia]) VALUES (1, 1, 1, 1, 1)
ALTER TABLE [dbo].[CHITIETHD]  WITH CHECK ADD FOREIGN KEY([Mahd])
REFERENCES [dbo].[HOADON] ([Mahd])
GO
ALTER TABLE [dbo].[CHITIETHD]  WITH CHECK ADD FOREIGN KEY([Masach])
REFERENCES [dbo].[SACH] ([Masach])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([Macv])
REFERENCES [dbo].[CHUCVU] ([Macv])
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD FOREIGN KEY([Maloai])
REFERENCES [dbo].[LOAISACH] ([Maloai])
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD FOREIGN KEY([Manv])
REFERENCES [dbo].[NHANVIEN] ([Manv])
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD FOREIGN KEY([Manxb])
REFERENCES [dbo].[NHAXUATBAN] ([Manxb])
GO
ALTER TABLE [dbo].[SACHNHASACH]  WITH CHECK ADD FOREIGN KEY([Masach])
REFERENCES [dbo].[SACH] ([Masach])
GO
ALTER TABLE [dbo].[SACHNHASACH]  WITH CHECK ADD FOREIGN KEY([Mans])
REFERENCES [dbo].[NHASACH] ([Mans])
GO
USE [master]
GO
ALTER DATABASE [#HeThongNhaSach] SET  READ_WRITE 
GO
