CREATE DATABASE DB_GIAOVIEN
GO

USE DB_GIAOVIEN
GO

--------------------------------------------------- [ KHỞI TẠO CÁC BẢNG DỮ LIỆU ] ---------------------------------------------------
--------------------- BẢNG GIÁO VIÊN
CREATE TABLE GIAOVIEN
(
	MAGV			VARCHAR(10),
	HOTEN			NVARCHAR(50),
	NGAYSINH		DATE,
	MATKHAU			VARCHAR(15),
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
	MAQTC			INT NOT NULL,
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
CREATE TABLE CHUCDANH
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
	CONSTRAINT PK_CHUNHIEM PRIMARY KEY(MALP)
);

--------------------- BẢNG BẰNG CẤP
CREATE TABLE BANGCAP
(
	MABC			VARCHAR(10) NOT NULL,
	TENBC			VARCHAR(50),
	CONSTRAINT PK_BANGCAP PRIMARY KEY(MABC)
);

--------------------- BẢNG CHI TIẾT BẰNG CẤP
CREATE TABLE CHITIETBANGCAP
(
	MABC			VARCHAR(10) NOT NULL,
	MAGV			VARCHAR(10) NOT NULL,
	NGAYCAP			DATE,
	CONSTRAINT PK_CHITIETBANGCAP PRIMARY KEY(MABC, MAGV)
);

--------------------- BẢNG CHUYÊN MÔN
CREATE TABLE CHUYENMON
(
	MACM			INT NOT NULL IDENTITY(1,1),
	TENCM			NVARCHAR(50),
	CONSTRAINT PK_CHUYENMON PRIMARY KEY(MACM)
);

--------------------- BẢNG QUYỀN TRUY CẬP
CREATE TABLE QUYENTRUYCAP
(
	MAQTC			INT NOT NULL IDENTITY(1,1),
	TENQTC			VARCHAR(50),
	CONSTRAINT PK_QUYENTRUYCAP PRIMARY KEY(MAQTC)
);

--------------------------------------------------- [ RÀNG BUỘC ] ---------------------------------------------------

--------------------------------------------------------- KHÓA NGOẠI
--------------------- BẢNG BẬC LƯƠNG
ALTER TABLE BACLUONG 
ADD CONSTRAINT FK_BACLUONG_CHUCDANH FOREIGN KEY(MASOCD) REFERENCES CHUCDANH(MASOCD)

--------------------- BẢNG GIÁO VIÊN
ALTER TABLE GIAOVIEN 
ADD CONSTRAINT FK_GIAOVIEN_BACLUONG FOREIGN KEY(MASOCD, BAC) REFERENCES BACLUONG(MASOCD, BAC),
	CONSTRAINT FK_GIAOVIEN_QUYENTRUYCAP FOREIGN KEY(MAQTC) REFERENCES QUYENTRUYCAP(MAQTC),
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


--------------------------------------------------------- TRIGGER
--------------------- TRIGGER TẠO RANDOM MÃ GIÁO VIÊN 
CREATE TRIGGER TAONGAUNHIENMAGIAOVIEN
ON GIAOVIEN
AFTER INSERT
AS
BEGIN    
    UPDATE GIAOVIEN
    SET MAGV = LEFT(CAST(ABS(CHECKSUM(NEWID())) AS VARCHAR(10)), 10)
END

--------------------------------------------------- [THÊM DỮ LIỆU VÀO CÁC BẢNG ] ---------------------------------------------------
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

--------------------- BẢNG CHỨC DANH
INSERT INTO CHUCDANH(MASOCD, HANGCD)
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
(N'Giáo dục công dân'),
(N'Tiếng Anh'),
(N'Tiếng Pháp'),
(N'Tiếng Trung'),
(N'Tin học'),
(N'Thể dục'),
(N'Âm nhạc'),
(N'Hội họa'),
(N'Giáo dục quốc phòng'),
(N'Tiếng Nhật'),
(N'Tiếng Đức')

--------------------- BẢNG GIÁO VIÊN
SET DATEFORMAT DMY
INSERT INTO GIAOVIEN(MAGV, HOTEN, NGAYSINH, MATKHAU, GIOITINH, DIACHI, SODIENTHOAI, CCCD, EMAIL, NGAYVAOTRUONG, NGAYVAODANG, DONVICONGTAC, DANTOC, TONGIAO, THAMNIEN, MASOCD, BAC, MACM, MAQTC)
VALUES
('GV001', N'Phạm Trần Tấn Đạt', '22/09/2002', '123123', N'Nam', N'Đường Lê Lợi, phường Bến Thành, quận 1, Thành phố Hồ Chí Minh', '0123456789',  '0123456789','datptt@slr.edu.vn', '23/05/2021', '27/06/2019', N'Trường THPT Bình Sơn', N'Kinh', N'Không',2, 'V.07.05.15', 1, 1, 2),
('GV002', N'Nguyễn Minh Khoa', '05/07/2002', '123123', N'Nữ', N'135 Nam Kỳ Khởi Nghĩa, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0987654321', '0123456789', 'khoanm@slr.edu.vn', '12/11/2020', '03/02/2019', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 3, 'V.07.05.15', 1, 3, 2),
('GV003', N'Tài Đại Duy Hùng', '02/07/2002', '123123', N'Nam', N'số 01 Công Xã Paris, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0932123456', '0123456789', 'hungtdd@slr.edu.vn', '02/03/2021', '30/07/2019', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 2, 'V.07.05.15', 1, 4, 2),
('GV004', N'Lê Hoàng Chương', '22/02/1985', '123123', N'Nữ', N'số 2 Nguyễn Bỉnh Khiêm, Quận 1, Thành phố Hồ Chí Minh', '0765432109', '0123456789', 'chuonglh@slr.edu.vn', '27/06/2017', '12/10/2008', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 6, 'V.07.05.15', 3, 8, 2),
('GV005', N'Lê Hoàng Anh', '28/09/1987', '123123', N'Nam', N'TL15, Phú Hiệp, Củ Chi, Thành phố Hồ Chí Minh', '0876543210', '0123456789', 'anhlh@slr.edu.vn', '13/11/2014', '13/05/2017', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 9, 'V.07.05.15', 9, 2, 2),
('GV006', N'Kiều Đạo Nhất San', '11/12/1991', '123123', N'Nữ', N'Đường Nguyễn Huệ, quận 1, Thành phố Hồ Chí Minh', '0654321098', '0123456789', 'sankdn@slr.edu.vn', '28/10/2020', '19/01/1998', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 3, 'V.07.05.15', 1, 18, 2),
('GV007', N'Trần Quốc Quy', '04/05/1989', '123123', N'Nam', N'2 Nguyễn Bỉnh Khiêm, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0987654321', '0123456789', 'quytq@slr.edu.vn', '01/06/2018', '09/01/2015', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 5, 'V.07.05.15', 4, 6, 2),
('GV008', N'Trần Thị Vân Anh', '23/08/1993', '123123', N'Nữ', N'số 2 Khu Him Lam, quận 7, Thành phố Hồ Chí Minh', '0210987654', '0123456789', 'anhttv@slr.edu.vn', '11/08/2016', '02/10/2016', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 7, 'V.07.05.15', 7, 7, 2),
('GV009', N'Đỗ Quang Vinh', '18/02/1986', '123123', N'Nam', N'Số 19-25 Nguyễn Huệ, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh', '0432109876', '0123456789', 'vinhdq@slr.edu.vn', '20/04/2013', '24/07/2005', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 10, 'V.07.05.14', 6, 12, 2),
('GV010', N'Nguyễn Thị Tuyết My', '12/02/1988', '123123', N'Nam', N'Số 3 Hòa Bình, phường 3, quận 11, Thành phố Hồ Chí Minh', '0765432109', '0123456789', 'myntt@slr.edu.vn', '02/01/2013', '30/09/2006', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 10, 'V.07.05.14', 3, 14, 2),
('GV011', N'Phạm Huyền Diệu', '19/05/1992', '123123', N'Nữ', N'180/45/26 Nguyễn Hữu Cảnh, Phường 22, Quận Bình Thạnh, Thành phố Hồ Chí Minh', '0654321098', '0123456789', 'dieuph@slr.edu.vn', '08/12/2011', '01/08/2014', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 12, 'V.07.05.14', 6, 8, 3),
('GV012', N'Trần Quang Trung', '09/06/1989', '123123', N'Nam', N'đường Bình Quới, phường 28, quận Bình Thạnh, thành phố Hồ Chí Minh', '0987654321', '0123456789', 'trungtq@slr.edu.vn', '09/03/2019', '07/02/2005', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 4, 'V.07.05.15', 1, 11, 2),
('GV013', N'Phan Tấn Trung', '21/09/1980', '123123', N'Nữ', N'191 đường Tam Đa, phường Trường Thạnh, quận 9, thành phố Hồ Chí Minh', '0210987654', '0123456789', 'trungpt@slr.edu.vn', '09/07/2012', '10/07/1999', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 11, 'V.07.05.14', 6, 4, 2),
('GV014', N'Phùng Thanh Độ', '14/04/1980', '123123', N'Nam', N'55C, đường Nguyễn Thị Minh Khai, quận 1, thành phố Hồ Chí Minh', '0432109876', '0123456789', 'dopt@slr.edu.vn', '08/04/2009', '26/05/2000', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 14, 'V.07.05.13', 2, 5, 2),
('GV015', N'Đặng Ngọc Bảo Châu', '27/07/1993', '123123', N'Nữ', N'48/10 Điện Biên Phủ, phường 22, quận Bình Thạnh, thành phố Hồ Chí Minh', '0876543210', '0123456789', 'chaudnb@slr.edu.vn', '06/01/2013', '25/07/2013', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 10, 'V.07.05.15', 9, 13, 2),
('GV016', N'Huỳnh Gia Khương', '30/10/1987', '123123', N'Nam', N'51/4/27 Thành Thái, Phường 14, Quận 10, Thành phố Hồ Chí Minh', '0765432109', '0123456789', 'khuonghg@slr.edu.vn', '22/03/2012', '21/08/2007', N'Trường THPT Bình Sơn', N'Hoa', N'Không', 11, 'V.07.05.15', 7, 9, 2),
('GV017', N'Lâm Quốc Huy', '13/01/1991', '123123', N'Nữ', N'346 Bến Vân Đồn, Phường 01, Quận 4, Thành phố Hồ Chí Minh', '0654321098', '0123456789', 'huylq@slr.edu.vn', '28/11/2017', '12/11/2015', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 6, 'V.07.05.15', 3, 16, 2),
('GV018', N'Đinh Sơn Tùng', '29/04/1988', '123123', N'Nam', N'số 53, đường số N8 Jamona City, Phường Phú Thuận, Quận 7, Thành phố Hồ Chí Minh', '0987654321', '0123456789', 'tungds@slr.edu.vn', '09/03/2014', '23/09/2000', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 9, 'V.07.05.15', 6, 15, 2),
('GV019', N'Đinh Thanh Hà', '12/07/1994', '123123', N'Nam', N'B70/2 Nguyễn Thần Hiến, Phường 18, Quận 4, Thành phố Hồ Chí Minh', '0210987654', '0123456789', 'hadt@slr.edu.vn', '24/01/2010', '09/11/2009', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 13, 'V.07.05.14', 8, 17, 2),
('GV020', N'Trần Trung Kiên', '31/10/1978', '123123', N'Nam', N'207B Hoàng Văn Thụ, Phường 08, Quận Phú Nhuận, Thành phố Hồ Chí Minh', '0210654987', '0123456789', 'kientt@slr.edu.vn', '29/04/2010', '03/01/2005', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 13, 'V.07.05.13', 1, 10, 2),
('GV021', N'Nguyễn Văn An', '01/01/1967', '123123', N'Nam', N'số 15 Nguyễn Lương Bằng, Phường Tân Phú, Quận 7, Thành phố Hồ Chí Minh', '0210987123', '0123456789', 'annv@slr.edu.vn', '02/07/2000', '09/02/1986', N'Trường THPT Bình Sơn', N'Kinh', N'Không', 23, 'V.07.05.13', 6, 1, 2),
('GV022', N'Trần Bích Phượng', '12/05/1977', '123123', N'Nữ', N'Số 851-853 đường Lê Hồng Phong, Phường 12, Quận 10, Thành phố Hồ Chí Minh', '0210123654', '0123456789', 'phuongtb@slr.edu.vn', '06/12/2005', '15/09/1997', N'Trường THPT Bình Sơn', N'Không', N'Kinh', 17, 'V.07.05.13', 4, 6, 2)








Select * from GIAOVIEN










