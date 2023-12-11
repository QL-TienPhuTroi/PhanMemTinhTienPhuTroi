CREATE DATABASE DB_GIAOVIEN
GO

USE DB_GIAOVIEN
GO

--------------------------------------------------- [ KHỞI TẠO CÁC BẢNG DỮ LIỆU ] ---------------------------------------------------
--------------------- BẢNG GIÁO VIÊN
CREATE TABLE GIAOVIEN
(
	MAGV			VARCHAR(10),
	TRANGTHAI		BIT,
	HOTEN			NVARCHAR(50),
	NGAYSINH		DATE,
	GIOITINH		NVARCHAR(5),
	DIACHI			NVARCHAR(200),
	SODIENTHOAI		VARCHAR(10),
	CCCD			VARCHAR(12),
	EMAIL			VARCHAR(30),
	NGAYVAOTRUONG	DATE,
	NGAYVAODANG		DATE,
	DONVICONGTAC	NVARCHAR(50),
	DANTOC			NVARCHAR(20),
	TONGIAO			NVARCHAR(25),
	THAMNIEN		INT,
	MASOCD			VARCHAR(10) NOT NULL,
	BAC				INT NOT NULL,
	MACM			INT NOT NULL,
	CONSTRAINT PK_GIAOVIEN PRIMARY KEY(MAGV)
);

--------------------- BẢNG CHỨC VỤ
CREATE TABLE CHUCVU
(
	MACV			INT NOT NULL IDENTITY(1,1),
	TENCV			NVARCHAR(50),
	CONSTRAINT PK_CHUCVU PRIMARY KEY(MACV)
);

--------------------- BẢNG ĐỊNH MỨC TIẾT DẠY
CREATE TABLE DINHMUCTIETDAY
(
	MACV				INT NOT NULL,
	SODINHMUCTIETDAY	DECIMAL(18,2),
	CONSTRAINT PK_DINHMUCTIETDAY PRIMARY KEY(MACV)
);

--------------------- BẢNG CHI TIẾT CHỨC VỤ
CREATE TABLE CHITIETCHUCVU
(
	MACV			INT NOT NULL,
	MAGV			VARCHAR(10) NOT NULL,
	CONSTRAINT PK_CHITIETCHUCVU PRIMARY KEY(MAGV, MACV)
);

--------------------- BẢNG CHỨC DANH
CREATE TABLE CHUCDANHNN
(
	MASOCD			VARCHAR(10) NOT NULL,
	HANGCD			NVARCHAR(50),
	CONSTRAINT PK_CHUCDANH PRIMARY KEY(MASOCD)
);

--------------------- BẢNG BẬC LƯƠNG
CREATE TABLE BACLUONG
(
	MASOCD			VARCHAR(10) NOT NULL,
	BAC				INT NOT NULL,
	HESOLUONG		DECIMAL(18,2),
	CONSTRAINT PK_BACLUONG PRIMARY KEY(MASOCD, BAC)
);

--------------------- BẢNG LỚP HỌC
CREATE TABLE LOPHOC
(
	MALP			VARCHAR(10) NOT NULL,
	TENLP			NVARCHAR(20),
	SISO			INT,
	KHIEMKHUYET		BIT,
	CONSTRAINT PK_LOPHOC PRIMARY KEY(MALP)
);

--------------------- BẢNG CHỦ NHIỆM
CREATE TABLE CHUNHIEM
(
	MALP			VARCHAR(10) NOT NULL,
	MAGV			VARCHAR(10) NOT NULL,
	NAMHOC			VARCHAR(15),
	TRANGTHAI		BIT,
	CONSTRAINT PK_CHUNHIEM PRIMARY KEY(MALP, MAGV, NAMHOC)
);

--------------------- BẢNG BẰNG CẤP
CREATE TABLE BANGCAP
(
	MABC			VARCHAR(10) NOT NULL,
	TENBC			NVARCHAR(50),
	NOIDAOTAO		NVARCHAR(100),
	CHUYENNGANH		NVARCHAR(100),
	HOCVI			NVARCHAR(20),
	XEPLOAI			NVARCHAR(20),
	NGAYCAP			DATE,
	CONSTRAINT PK_BANGCAP PRIMARY KEY(MABC)
);

--------------------- BẢNG CHI TIẾT BẰNG CẤP
CREATE TABLE CHITIETBANGCAP
(
	MABC			VARCHAR(10) NOT NULL,
	MAGV			VARCHAR(10) NOT NULL,
	CONSTRAINT PK_CHITIETBANGCAP PRIMARY KEY(MABC, MAGV)
);

--------------------- BẢNG CHUYÊN MÔN
CREATE TABLE CHUYENMON
(
	MACM			INT NOT NULL IDENTITY(1,1),
	TENCM			NVARCHAR(50),
	CONSTRAINT PK_CHUYENMON PRIMARY KEY(MACM)
);

--------------------- BẢNG MÔN HỌC
CREATE TABLE MONHOC
(
	MAMH			INT NOT NULL IDENTITY(1,1),
	TENMH			NVARCHAR(50),
	CONSTRAINT PK_MONHOC PRIMARY KEY(MAMH)
);


--------------------- BẢNG LỊCH DẠY
CREATE TABLE LICHDAY
(
	MALICH			VARCHAR(12) NOT NULL,
	MAGV			VARCHAR(10) NOT NULL,
	MAMH			INT NOT NULL,
	MALP			VARCHAR(10) NOT NULL,
	THOIGIANBATDAU	DATE,
	THOIGIANKETTHUC	DATE,
	NAMHOC			VARCHAR(15),
	CONSTRAINT PK_LICHDAY PRIMARY KEY(MALICH)
);

--------------------- BẢNG CHI TIẾT LỊCH DẠY
CREATE TABLE CHITIETLICHDAY
(
	MALICH			VARCHAR(12) NOT NULL,
	THU				NVARCHAR(10),
	NGAYDAY			DATE,
	TIETDAY			INT,
	CONSTRAINT PK_CHITIETLICHDAY PRIMARY KEY(MALICH, NGAYDAY, TIETDAY)
);

--------------------- BẢNG THỜI GIAN DẠY
CREATE TABLE THOIGIANDAY
(
	MATG			INT NOT NULL IDENTITY(1,1),
	TENTIET			INT,
	GIOBATDAU		TIME(7),
	GIOKETTHUC		TIME(7),
	CONSTRAINT PK_THOIGIANDAY PRIMARY KEY(MATG)
);

--------------------- BẢNG QUYỀN TRUY CẬP
CREATE TABLE QUYENTRUYCAP
(
	MAQTC			INT NOT NULL IDENTITY(1,1),
	TENQTC			VARCHAR(50),
	CONSTRAINT PK_QUYENTRUYCAP PRIMARY KEY(MAQTC)
);

--------------------- BẢNG TÀI KHOẢN
CREATE TABLE TAIKHOAN
(
	MAGV			VARCHAR(10) NOT NULL,
	MATKHAU			VARCHAR(15),
	MAQTC			INT NOT NULL,
	CONSTRAINT PK_TAIKHOAN PRIMARY KEY(MAGV)
);

--------------------------------------------------- [ RÀNG BUỘC ] ---------------------------------------------------

--------------------------------------------------------- KHÓA NGOẠI
--------------------- BẢNG BẬC LƯƠNG
ALTER TABLE BACLUONG 
ADD CONSTRAINT FK_BACLUONG_CHUCDANHNN FOREIGN KEY(MASOCD) REFERENCES CHUCDANHNN(MASOCD)

--------------------- BẢNG GIÁO VIÊN
ALTER TABLE GIAOVIEN 
ADD CONSTRAINT FK_GIAOVIEN_BACLUONG FOREIGN KEY(MASOCD, BAC) REFERENCES BACLUONG(MASOCD, BAC),
	CONSTRAINT FK_GIAOVIEN_CHUYENMON FOREIGN KEY(MACM) REFERENCES CHUYENMON(MACM)

--------------------- BẢNG CHỦ NHIỆM
ALTER TABLE CHUNHIEM 
ADD CONSTRAINT FK_CHUNHIEM_LOPHOC FOREIGN KEY(MALP) REFERENCES LOPHOC(MALP),
	CONSTRAINT FK_CHUNHIEM_GIAOVIEN FOREIGN KEY(MAGV) REFERENCES GIAOVIEN(MAGV)

--------------------- BẢNG ĐỊNH MỨC TIẾT DẠY
ALTER TABLE DINHMUCTIETDAY
ADD CONSTRAINT FK_DINHMUCTIETDAY_CHUCVU FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV)

--------------------- BẢNG CHI TIẾT CHỨC VỤ
ALTER TABLE CHITIETCHUCVU
ADD CONSTRAINT FK_CHITIETCHUCVU_GIAOVIEN FOREIGN KEY(MAGV) REFERENCES GIAOVIEN(MAGV),
	CONSTRAINT FK_CHITIETCHUCVU_CHUCVU FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV)

--------------------- BẢNG CHI TIẾT BẰNG CẤP
ALTER TABLE CHITIETBANGCAP
ADD CONSTRAINT FK_CHITIETBANGCAP_GIAOVIEN FOREIGN KEY(MAGV) REFERENCES GIAOVIEN(MAGV),
	CONSTRAINT FK_CHITIETBANGCAP_BANGCAP FOREIGN KEY(MABC) REFERENCES BANGCAP(MABC)

--------------------- BẢNG TÀI KHOẢN
ALTER TABLE TAIKHOAN
ADD CONSTRAINT FK_TAIKHOAN_GIAOVIEN FOREIGN KEY(MAGV) REFERENCES GIAOVIEN(MAGV),
	CONSTRAINT FK_TAIKHOAN_QUYENTRUYCAP FOREIGN KEY(MAQTC) REFERENCES QUYENTRUYCAP(MAQTC)

--------------------- BẢNG LỊCH HỌC
ALTER TABLE LICHDAY
ADD CONSTRAINT FK_LICHDAY_GIAOVIEN FOREIGN KEY(MAGV) REFERENCES GIAOVIEN(MAGV),
	CONSTRAINT FK_LICHDAY_MONHOC FOREIGN KEY(MAMH) REFERENCES MONHOC(MAMH),
	CONSTRAINT FK_LICHDAY_LOPHOC FOREIGN KEY(MALP) REFERENCES LOPHOC(MALP)

--------------------- BẢNG CHI TIẾT LỊCH HỌC
ALTER TABLE CHITIETLICHDAY
ADD CONSTRAINT FK_CHITIETLICHDAY_LICHDAY FOREIGN KEY(MALICH) REFERENCES LICHDAY(MALICH),
	CONSTRAINT FK_CHITIETLICHDAY_THOIGIANDAY FOREIGN KEY(TIETDAY) REFERENCES THOIGIANDAY(MATG)

--------------------------------------------------- [THÊM DỮ LIỆU VÀO CÁC BẢNG ] ---------------------------------------------------

--------------------- BẢNG THỜI GIAN DẠY
INSERT INTO THOIGIANDAY (TENTIET, GIOBATDAU, GIOKETTHUC)
VALUES
(1, '07:00', '07:45'),
(2, '07:50', '08:35'),
(3, '08:40', '09:25'),
(4, '09:50', '10:35'),
(5, '10:40', '11:25'),
(6, '13:00', '13:45'),
(7, '13:50', '14:35'),
(8, '14:40', '15:25'),
(9, '15:50', '16:35'),
(10, '16:40', '17:25')

--------------------- BẢNG CHỨC VỤ
INSERT INTO CHUCVU (TENCV)
VALUES
(N'Hiệu trưởng'),
(N'Phó hiệu trưởng'),
(N'Giáo viên giảng dạy HS tàn tật, khuyết tật'),
(N'Giáo viên')

--------------------- BẢNG ĐỊNH MỨC TIẾT DẠY
INSERT INTO DINHMUCTIETDAY (MACV, SODINHMUCTIETDAY)
VALUES
(1, 2),
(2, 4),
(3, 15),
(4, 17)

--------------------- BẢNG CHỨC DANH NGHỀ NGHIỆP
INSERT INTO CHUCDANHNN(MASOCD, HANGCD)
VALUES
('V.07.05.13', N'Giáo viên THPT hạng I'),
('V.07.05.14', N'Giáo viên THPT hạng II'),
('V.07.05.15', N'Giáo viên THPT hạng III')

--------------------- BẢNG BẬC LƯƠNG
INSERT INTO BACLUONG(MASOCD, BAC, HESOLUONG)
VALUES
('V.07.05.15', 1, 2.34),
('V.07.05.15', 2, 2.67),
('V.07.05.15', 3, 3),
('V.07.05.15', 4, 3.33),
('V.07.05.15', 5, 3.66),
('V.07.05.15', 6, 3.99),
('V.07.05.15', 7, 4.32),
('V.07.05.15', 8, 4.65),
('V.07.05.15', 9, 4.98),
('V.07.05.14', 1, 4),
('V.07.05.14', 2, 4.34),
('V.07.05.14', 3, 4.68),
('V.07.05.14', 4, 5.02),
('V.07.05.14', 5, 5.36),
('V.07.05.14', 6, 5.7),
('V.07.05.14', 7, 6.04),
('V.07.05.14', 8, 6.38),
('V.07.05.13', 1, 4.4),
('V.07.05.13', 2, 4.74),
('V.07.05.13', 3, 5.08),
('V.07.05.13', 4, 5.42),
('V.07.05.13', 5, 5.76),
('V.07.05.13', 6, 6.1),
('V.07.05.13', 7, 6.44),
('V.07.05.13', 8, 6.78)

--------------------- BẢNG QUYỀN TRUY CẬP
INSERT INTO QUYENTRUYCAP(TENQTC)
VALUES
(N'Nhân viên quản lý'),
(N'Giáo viên'),
(N'Kế toán')

--------------------- BẢNG CHUYÊN MÔN
INSERT INTO CHUYENMON(TENCM)
VALUES 
(N'Toán học'),
(N'Ngữ văn'),
(N'Vật lý'),
(N'Hóa học'),
(N'Sinh học'),
(N'Lịch sử'),
(N'Địa lý'),
(N'GDCD'),
(N'Tiếng Anh'),
(N'Công nghệ'),
(N'Tiếng Trung'),
(N'Tin học'),
(N'Thể dục'),
(N'Âm nhạc'),
(N'Hội họa'),
(N'GDQP'),
(N'Tiếng Nhật'),
(N'Tiếng Đức')

--------------------- BẢNG MÔN HỌC
INSERT INTO MONHOC(TENMH)
VALUES 
(N'Toán học'),
(N'Ngữ văn'),
(N'Vật lý'),
(N'Hóa học'),
(N'Sinh học'),
(N'Lịch sử'),
(N'Địa lý'),
(N'GDCD'),
(N'Tiếng Anh'),
(N'Công nghệ'),
(N'Tiếng Trung'),
(N'Tin học'),
(N'Thể dục'),
(N'Âm nhạc'),
(N'Hội họa'),
(N'GDPQ'),
(N'Tiếng Nhật'),
(N'Tiếng Đức')

--------------------- BẢNG GIÁO VIÊN
SET DATEFORMAT DMY
INSERT INTO GIAOVIEN(MAGV, TRANGTHAI, HOTEN, NGAYSINH, GIOITINH, DIACHI, SODIENTHOAI, CCCD, EMAIL, NGAYVAOTRUONG, NGAYVAODANG, DONVICONGTAC, DANTOC, TONGIAO, THAMNIEN, MASOCD, BAC, MACM)
VALUES
('2001103392', 1, N'Phạm Trần Tấn Đạt', '22/09/2002', N'Nam', N'Đường Lê Lợi, phường Bến Thành, quận 1, Thành phố Hồ Chí Minh', '0123456789',  '0123456789','datptt@slr.edu.vn', '23/05/2021', '27/06/2019', N'Trường THPT Bình Sơn', N'Kinh', N'Không',2, 'V.07.05.15', 1, 1),
('2001114243', 1, N'Nguyễn Minh Khoa', '05/07/2002', N'Nam', N'135 Nam Kỳ Khởi Nghĩa, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0987654321', '0123456789', 'khoanm@slr.edu.vn', '12/11/2020', '03/02/2019', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 3, 'V.07.05.15', 1, 3),
('2001116218', 1, N'Tài Đại Duy Hùng', '02/07/2002', N'Nam', N'số 01 Công Xã Paris, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0932123456', '0123456789', 'hungtdd@slr.edu.vn', '02/03/2021', '30/07/2019', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 2, 'V.07.05.15', 1, 4),
('2001128009', 1, N'Lê Hoàng Chương', '22/02/1985', N'Nam', N'số 2 Nguyễn Bỉnh Khiêm, Quận 1, Thành phố Hồ Chí Minh', '0765432109', '0123456789', 'chuonglh@slr.edu.vn', '27/06/2017', '12/10/2008', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 6, 'V.07.05.15', 3, 8),
('2001129533', 1, N'Lê Hoàng Anh', '28/09/1987', N'Nam', N'TL15, Phú Hiệp, Củ Chi, Thành phố Hồ Chí Minh', '0876543210', '0123456789', 'anhlh@slr.edu.vn', '13/11/2014', '13/05/2017', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 9, 'V.07.05.15', 9, 2),
('2001135986', 1, N'Kiều Đạo Nhất San', '11/12/1991', N'Nam', N'Đường Nguyễn Huệ, quận 1, Thành phố Hồ Chí Minh', '0654321098', '0123456789', 'sankdn@slr.edu.vn', '28/10/2020', '19/01/1998', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 3, 'V.07.05.15', 1, 18),
('2001140172', 1, N'Trần Quốc Quy', '04/05/1989', N'Nam', N'2 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0987654321', '0123456789', 'quytq@slr.edu.vn', '01/06/2018', '09/01/2015', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 5, 'V.07.05.15', 4, 6),
('2001150068', 1, N'Trần Thị Vân Anh', '23/08/1993', N'Nữ', N'số 2 Khu Him Lam, quận 7, Thành phố Hồ Chí Minh', '0210987654', '0123456789', 'anhttv@slr.edu.vn', '11/08/2016', '02/10/2016', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 7, 'V.07.05.15', 7, 7),
('2001161738', 1, N'Đỗ Quang Vinh', '18/02/1986', N'Nam', N'Số 19-25 Nguyễn Huệ, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0432109876', '0123456789', 'vinhdq@slr.edu.vn', '20/04/2013', '24/07/2005', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 10, 'V.07.05.14', 6, 12),
('2001162764', 1, N'Nguyễn Thị Tuyết My', '12/02/1988', N'Nữ', N'Số 3 Hòa Bình, phường 3, quận 11, Thành phố Hồ Chí Minh', '0765432109', '0123456789', 'myntt@slr.edu.vn', '02/01/2013', '30/09/2006', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 10, 'V.07.05.14', 3, 14),
('2001163272', 1, N'Phạm Huyền Diệu', '19/05/1992', N'Nữ', N'180/45/26 Nguyễn Hữu Cảnh, Phường 22, Quận Bình Thạnh, Thành phố Hồ Chí Minh', '0654321098', '0123456789', 'dieuph@slr.edu.vn', '08/12/2011', '01/08/2014', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 12, 'V.07.05.14', 6, 8),
('2001177302', 1, N'Trần Quang Trung', '09/06/1989', N'Nam', N'đường Bình Quới, phường 28, quận Bình Thạnh, thành phố Hồ Chí Minh', '0987654321', '0123456789', 'trungtq@slr.edu.vn', '09/03/2019', '07/02/2005', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 4, 'V.07.05.15', 1, 11),
('2001200374', 1, N'Phan Tấn Trung', '21/09/1980', N'Nam', N'191 đường Tam Đa, phường Trường Thạnh, quận 9, thành phố Hồ Chí Minh', '0210987654', '0123456789', 'trungpt@slr.edu.vn', '09/07/2012', '10/07/1999', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 11, 'V.07.05.14', 6, 4),
('2001202625', 1, N'Phùng Thanh Độ', '14/04/1980', N'Nam', N'55C, đường Nguyễn Thị Minh Khai, quận 1, thành phố Hồ Chí Minh', '0432109876', '0123456789', 'dopt@slr.edu.vn', '08/04/2009', '26/05/2000', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 14, 'V.07.05.13', 2, 5),
('2001286962', 1, N'Đặng Ngọc Bảo Châu', '27/07/1993', N'Nữ', N'48/10 Điện Biên Phủ, phường 22, quận Bình Thạnh, thành phố Hồ Chí Minh', '0876543210', '0123456789', 'chaudnb@slr.edu.vn', '06/01/2013', '25/07/2013', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 10, 'V.07.05.15', 9, 13),
('2001466041', 1, N'Huỳnh Gia Khương', '30/10/1987', N'Nam', N'51/4/27 Thành Thái, Phường 14, Quận 10, Thành phố Hồ Chí Minh', '0765432109', '0123456789', 'khuonghg@slr.edu.vn', '22/03/2012', '21/08/2007', N'Trường THPT Bình Sơn', N'Hoa', N'Không', 11, 'V.07.05.15', 7, 9),
('2001570500', 1, N'Lâm Quốc Huy', '13/01/1991', N'Nam', N'346 Bến Vân Đồn, Phường 01, Quận 4, Thành phố Hồ Chí Minh', '0654321098', '0123456789', 'huylq@slr.edu.vn', '28/11/2017', '12/11/2015', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 6, 'V.07.05.15', 3, 16),
('2001641485', 1, N'Đinh Sơn Tùng', '29/04/1988', N'Nam', N'số 53, đường số N8 Jamona City, Phường Phú Thuận, Quận 7, Thành phố Hồ Chí Minh', '0987654321', '0123456789', 'tungds@slr.edu.vn', '09/03/2014', '23/09/2000', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 9, 'V.07.05.15', 6, 15),
('2001706433', 1, N'Đinh Thanh Hà', '12/07/1994', N'Nam', N'B70/2 Nguyễn Thần Hiến, Phường 18, Quận 4, Thành phố Hồ Chí Minh', '0210987654', '0123456789', 'hadt@slr.edu.vn', '24/01/2010', '09/11/2009', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 13, 'V.07.05.14', 8, 17),
('2001787274', 1, N'Trần Trung Kiên', '31/10/1978', N'Nam', N'207B Hoàng Văn Thụ, Phường 08, Quận Phú Nhuận, Thành phố Hồ Chí Minh', '0210654987', '0123456789', 'kientt@slr.edu.vn', '29/04/2010', '03/01/2005', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 13, 'V.07.05.13', 1, 10),
('2001802284', 1, N'Nguyễn Văn An', '01/01/1967', N'Nam', N'số 15 Nguyễn Lương Bằng, Phường Tân Phú, Quận 7, Thành phố Hồ Chí Minh', '0210987123', '0123456789', 'annv@slr.edu.vn', '02/07/2000', '09/02/1986', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 23, 'V.07.05.13', 6, 1),
('2001878553', 1, N'Trần Bích Phượng', '12/05/1977', N'Nữ', N'Số 851-853 đường Lê Hồng Phong, Phường 12, Quận 10, Thành phố Hồ Chí Minh', '0210123654', '0123456789', 'phuongtb@slr.edu.vn', '06/12/2005', '15/09/1997', N'Trường THPT Bình Sơn', N'Không', N'Kinh', 17, 'V.07.05.13', 4, 6)

--------------------- BẢNG TÀI KHOẢN
INSERT INTO TAIKHOAN(MAGV, MATKHAU, MAQTC)
VALUES
('2001103392', '123123', 2),
('2001114243', '123123', 2),
('2001116218', '123123', 2),
('2001128009', '123123', 2),
('2001129533', '123123', 2),
('2001135986', '123123', 2),
('2001140172', '123123', 2),
('2001150068', '123123', 2),
('2001161738', '123123', 2),
('2001162764', '123123', 2),
('2001163272', '123123', 2),
('2001177302', '123123', 2),
('2001200374', '123123', 2),
('2001202625', '123123', 2),
('2001286962', '123123', 2),
('2001466041', '123123', 2),
('2001570500', '123123', 2),
('2001641485', '123123', 2),
('2001706433', '123123', 2),
('2001787274', '123123', 2),
('2001802284', '123123', 1),
('2001878553', '123123', 2)

--------------------- BẢNG LỚP HỌC
INSERT INTO LOPHOC(MALP, TENLP, SISO, KHIEMKHUYET)
VALUES
('LP10016752', '10A1', 41, 0),
('LP10012797', '10A2', 41, 0),
('LP10012550', '10A3', 41, 0),
('LP10014457', '10C1', 41, 1),
('LP10017324', '10C2', 41, 1),
('LP10015831', '10C3', 41, 1),
('LP10019683', '11A1', 41, 0),
('LP10015456', '11A2', 41, 0),
('LP10011843', '11A3', 41, 0),
('LP10019191', '11C1', 41, 0),
('LP10013465', '11C2', 41, 0),
('LP10013251', '11C3', 41, 0),
('LP10015425', '12A1', 41, 1),
('LP10016744', '12A2', 41, 0),
('LP10015934', '12A3', 41, 0),
('LP10019370', '12C1', 41, 0),
('LP10012585', '12C2', 41, 0),
('LP10014649', '12C3', 41, 0)

--------------------- BẢNG CHI TIẾT CHỨC VỤ
INSERT INTO CHITIETCHUCVU(MACV, MAGV)
VALUES
(4, '2001466041'),
(4, '2001129533'),
(4, '2001103392'),
(4, '2001114243'),
(4, '2001116218'),
(4, '2001128009'),
(4, '2001135986'),
(4, '2001140172'),
(4, '2001150068'),
(4, '2001161738'),
(4, '2001162764'),
(4, '2001163272'),
(4, '2001177302'),
(4, '2001200374'),
(4, '2001202625'),
(4, '2001286962'),
(4, '2001570500'),
(4, '2001641485'),
(4, '2001706433'),
(4, '2001787274'),
(1, '2001802284'),
(2, '2001878553')




----------------------------------- TEST











