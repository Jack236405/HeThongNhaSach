USE [#HeThongNhaSach]
GO
SET IDENTITY_INSERT [dbo].[CHUCVU] ON 

INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (1, N'Bộ phận điều hành', N'BPDH_2                                                                                              ', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (2, N'Nhân viên quản lý', N'NVQL_1                                                                                              ', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (3, N'Quản lý nhập hàng', N'QLNH_1                                                                                              ', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef')
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (4, N'Quản lý nhân sự', NULL, NULL)
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (5, N'Nhân viên bán hàng', NULL, NULL)
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (6, N'Kế toán bán hàng', NULL, NULL)
INSERT [dbo].[CHUCVU] ([Macv], [Tencv], [Taikhoan], [Matkhau]) VALUES (18, N'1', N'11                                                                                                  ', N'1      2                                ')
SET IDENTITY_INSERT [dbo].[CHUCVU] OFF
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV01', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Nguyễn Văn A', N'F2 Cần Thơ', NULL, 1, 1, 1, 6.5)
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV02', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Nguyễn Văn B', N'F1 Cần Thơ', NULL, 1, 2, 1, 7)
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV03', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'Nguyễn Văn C', N'729. F22', CAST(N'2022-05-13' AS Date), 1, 2, NULL, NULL)
INSERT [dbo].[NHANVIEN] ([Manv], [Matkhau], [Hoten], [Diachi], [Ngaysinh], [Phai], [Macv], [Phucap], [Luong]) VALUES (N'NV04', N'40bd001563085fc35165329ea1ff5c5ecbdbbeef', N'04', N'04', CAST(N'2022-05-19' AS Date), 1, 3, 1, 1)
SET IDENTITY_INSERT [dbo].[LOAISACH] ON 

INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (1, N'Chính trị – pháp luật')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (2, N'Khoa học công nghệ – Kinh tế')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (3, N'Văn học nghệ thuật')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (4, N'Truyện, tiểu thuyết')
INSERT [dbo].[LOAISACH] ([Maloai], [Tenloai]) VALUES (5, N'1')
SET IDENTITY_INSERT [dbo].[LOAISACH] OFF
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
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([Mahd], [Loaihd], [Ngaylap], [Manv], [Tinhtrang]) VALUES (1, 1, CAST(N'2022-05-29' AS Date), N'NV04', 1)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
INSERT [dbo].[CHITIETHD] ([Mahd], [Masach], [Soluong], [Dongia]) VALUES (1, 1, 10, 50000)
SET IDENTITY_INSERT [dbo].[NHASACH] ON 

INSERT [dbo].[NHASACH] ([Mans], [Tenns], [Diachi], [Std]) VALUES (1, N'Sách Mới', N'Long Xuyên', NULL)
SET IDENTITY_INSERT [dbo].[NHASACH] OFF
INSERT [dbo].[SACHNHASACH] ([Mans], [Masach], [Soluong], [Chietkhau], [Dongia]) VALUES (1, 1, 1, 1, 1)
