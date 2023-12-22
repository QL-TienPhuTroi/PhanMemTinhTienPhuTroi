using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL
{
    public class ChiTietLichDayBLL
    {
        ChiTietLichDayDAL ctld_dal = new ChiTietLichDayDAL();

        public ChiTietLichDayBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT LỊCH DẠY
        public List<ChiTietLichDayDTO> getDataChiTietLichDay()
        {
            return ctld_dal.getDataChiTietLichDay();
        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT LỊCH DẠY THEO MÃ LỊCH
        public List<ChiTietLichDayDTO> getDataChiTietLichDay(string pMaLich)
        {
            return ctld_dal.getDataChiTietLichDay(pMaLich);
        }

        //------------------ KIỂM TRA TRÙNG MÔN
        public bool checkTrungMon(int pMaMH, DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.checkTrungMon(pMaMH, pNgayDay, pTietDay);
        }

        //------------------ KIỂM TRA TRÙNG LỊCH CÙNG LỚP
        public bool checkTrungLichCungLop(string pMaLop, DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.checkTrungLichCungLop(pMaLop, pNgayDay, pTietDay);
        }

        //------------------ KIỂM TRA TRÙNG LỊCH KHÁC LỚP
        public bool checkTrungLichKhacLop(string pMaGV, DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.checkTrungLichKhacLop(pMaGV, pNgayDay, pTietDay);
        }

        //------------------ LẤY TÊN MÔN HỌC CÙNG LỚP
        public string getNameLessonCungLop(string pMaLop, DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.getNameLessonCungLop(pMaLop, pNgayDay, pTietDay);
        }

        //------------------ LẤY TÊN MÔN HỌC KHÁC LỚP LỚP
        public string getNameLessonKhacLop(string pMaGV, DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.getNameLessonKhacLop(pMaGV, pNgayDay, pTietDay);
        }

        //------------------ LẤY TÊN MÔN HỌC
        public string getNameClassroom(DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.getNameClassroom(pNgayDay, pTietDay);
        }

        public DateTime FindStartOfWeek(DateTime ngayBatKy)
        {
            return ctld_dal.FindStartOfWeek(ngayBatKy);
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 TUẦN CỦA GIÁO VIÊN
        public int getCountLessonInWeek(string pMaGV, DateTime pNgayDauTuan, string pNamHoc)
        {
            return ctld_dal.getCountLessonInWeek(pMaGV, pNgayDauTuan, pNamHoc);
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 TUẦN CỦA GIÁO VIÊN DẠY MÔN HỌC CỤ THỂ
        public int getCountLessonInWeek(string pMaGV, DateTime pNgayDauTuan, string pNamHoc, int pMaMH, string pMaLop)
        {
            return ctld_dal.getCountLessonInWeek(pMaGV, pNgayDauTuan, pNamHoc, pMaMH, pMaLop);
        }

        //------------------ ĐẾM SỐ TIẾT ĐÃ DẠY TRONG 1 NĂM HỌC CỦA GIÁO VIÊN
        public int getCountLessonTeachingInWeek(string pMaGV, DateTime pNgayDauTuan, string pNamHoc)
        {
            return ctld_dal.getCountLessonTeachingInWeek(pMaGV, pNgayDauTuan, pNamHoc);
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 NĂM HỌC CỦA GIÁO VIÊN
        public int getCountLessonInYear(string pMaGV, string pNamHoc)
        {
            return ctld_dal.getCountLessonInYear(pMaGV, pNamHoc);
        }

        //------------------ ĐẾM SỐ TIẾT ĐÃ DẠY TRONG 1 NĂM HỌC CỦA GIÁO VIÊN
        public int getCountLessonTeachingInYear(string pMaGV, string pNamHoc)
        {
            return ctld_dal.getCountLessonTeachingInYear(pMaGV, pNamHoc);
        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY THEO NGÀY
        public List<ChiTietLichDayLocDTO> getDataLessonDaily(DateTime pNgayDay)
        {
            return ctld_dal.getDataLessonDaily(pNgayDay);
        }

        //------------------ THÊM CHI TIẾT LỊCH DẠY
        public void addCTLD(ChiTietLichDayDTO ctld)
        {
            ctld_dal.addCTLD(ctld);
        }

        //------------------ XÓA CHI TIẾT LỊCH DẠY
        public bool removeCTLD(string pMaLich)
        {
            return ctld_dal.removeCTLD(pMaLich);
        }

        //------------------ XÓA CHI TIẾT LỊCH DẠY
        public bool removeCTLD(string pMaLich, DateTime pNgayDay)
        {
            return ctld_dal.removeCTLD(pMaLich, pNgayDay);
        }

        //------------------ XÓA CHI TIẾT LỊCH DẠY
        public bool removeCTLD(string pMaLich, string pThu)
        {
            return ctld_dal.removeCTLD(pMaLich, pThu);
        }

        //------------------ XÓA CHI TIẾT LỊCH DẠY
        public bool removeCTLD(string pMaLich, DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.removeCTLD(pMaLich, pNgayDay, pTietDay);
        }

        //------------------ SỬA CHI TIẾT LỊCH DẠY
        public void editCTLD(ChiTietLichDayDTO ctld)
        {
            ctld_dal.editCTLD(ctld);
        }
    }
}
