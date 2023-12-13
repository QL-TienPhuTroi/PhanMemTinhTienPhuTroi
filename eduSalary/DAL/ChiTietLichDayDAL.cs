using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class ChiTietLichDayDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ChiTietLichDayDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT LỊCH DẠY
        public List<ChiTietLichDayDTO> getDataChiTietLichDay()
        {
            var chitietlichdays = from ctld in qlgv.CHITIETLICHDAYs select new ChiTietLichDayDTO()
            {
                malich = ctld.MALICH,
                thu = ctld.THU,
                ngayday = (DateTime)ctld.NGAYDAY,
                tietday = (int)ctld.TIETDAY
            };

            List<ChiTietLichDayDTO> lst_ctld = chitietlichdays.ToList();

            return lst_ctld;
        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT LỊCH DẠY THEO MÃ LỊCH
        public List<ChiTietLichDayDTO> getDataChiTietLichDay(string pMaLich)
        {
            var chitietlichdays = from ctld in qlgv.CHITIETLICHDAYs where ctld.MALICH == pMaLich select new ChiTietLichDayDTO()
            {
                malich = ctld.MALICH,
                thu = ctld.THU,
                ngayday = (DateTime)ctld.NGAYDAY,
                tietday = (int)ctld.TIETDAY
            };

            chitietlichdays = chitietlichdays.OrderBy(ctld => ctld.thu);


            List<ChiTietLichDayDTO> lst_ctld = chitietlichdays.ToList();

            return lst_ctld;
        }

        //------------------ KIỂM TRA TRÙNG MÔN
        public bool checkTrungMon(int pMaMH, DateTime pNgayDay, int pTietDay)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH where ld.MAMH == pMaMH && ctld.NGAYDAY == pNgayDay && ctld.TIETDAY == pTietDay select ctld;
            return query.Any();
        }

        //------------------ KIỂM TRA TRÙNG LỊCH CÙNG LỚP
        public bool checkTrungLichCungLop(string pMaLop, DateTime pNgayDay, int pTietDay)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH where ld.MALP == pMaLop && ctld.NGAYDAY == pNgayDay && ctld.TIETDAY == pTietDay select ctld;
            return query.Any();
        }

        //------------------ KIỂM TRA TRÙNG LỊCH KHÁC LỚP
        public bool checkTrungLichKhacLop(string pMaGV, DateTime pNgayDay, int pTietDay)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH where ld.MAGV == pMaGV && ctld.NGAYDAY == pNgayDay && ctld.TIETDAY == pTietDay select ctld;
            return query.Any();
        }

        //------------------ LẤY TÊN MÔN HỌC CÙNG LỚP
        public string getNameLessonCungLop(string pMaLop, DateTime pNgayDay, int pTietDay)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH join mh in qlgv.MONHOCs on ld.MAMH equals mh.MAMH where ld.MALP == pMaLop && ctld.NGAYDAY == pNgayDay && ctld.TIETDAY == pTietDay select mh.TENMH;
            return query.FirstOrDefault();
        }

        //------------------ LẤY TÊN MÔN HỌC KHÁC LỚP LỚP
        public string getNameLessonKhacLop(string pMaGV, DateTime pNgayDay, int pTietDay)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH join mh in qlgv.MONHOCs on ld.MAMH equals mh.MAMH where ld.MAGV == pMaGV && ctld.NGAYDAY == pNgayDay && ctld.TIETDAY == pTietDay select mh.TENMH;
            return query.FirstOrDefault();
        }

        //------------------ LẤY TÊN MÔN HỌC
        public string getNameClassroom(DateTime pNgayDay, int pTietDay)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH join lp in qlgv.LOPHOCs on ld.MALP equals lp.MALP where ctld.NGAYDAY == pNgayDay && ctld.TIETDAY == pTietDay select lp.TENLP;
            return query.FirstOrDefault();
        }

        public DateTime FindStartOfWeek(DateTime ngayBatKy)
        {
            DateTime ngayDauTuan = Enumerable.Range(-(int)ngayBatKy.DayOfWeek, 7)
                                              .Select(offset => ngayBatKy.AddDays(offset))
                                              .First();

            return ngayDauTuan;
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 TUẦN CỦA GIÁO VIÊN
        public int getCountLessonInWeek(string pMaGV, DateTime pNgayDauTuan)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH where ld.MAGV == pMaGV && ctld.NGAYDAY >= pNgayDauTuan && ctld.NGAYDAY <= pNgayDauTuan.AddDays(6) select ctld;
            return query.Count();
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 NĂM HỌC CỦA GIÁO VIÊN
        public int getCountLessonInYear(string pMaGV)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH where ld.MAGV == pMaGV select ctld;
            return query.Count();
        }

        //------------------ THÊM CHI TIẾT LỊCH DẠY
        public void addCTLD(ChiTietLichDayDTO ctld)
        {
            CHITIETLICHDAY ctlds = new CHITIETLICHDAY();

            ctlds.MALICH = ctld.malich;
            ctlds.THU = ctld.thu;
            ctlds.NGAYDAY = ctld.ngayday;
            ctlds.TIETDAY = ctld.tietday;
            
            qlgv.CHITIETLICHDAYs.InsertOnSubmit(ctlds);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA CHI TIẾT LỊCH DẠY
        public bool removeCTLD(string pMaLich, DateTime pNgayDay, int pTietDay)
        {
            CHITIETLICHDAY ctld = qlgv.CHITIETLICHDAYs.Where(t => t.MALICH == pMaLich && t.NGAYDAY == pNgayDay && t.TIETDAY == pTietDay).FirstOrDefault();
            if (ctld != null)
            {
                qlgv.CHITIETLICHDAYs.DeleteOnSubmit(ctld);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA CHI TIẾT LỊCH DẠY
        public void editCTLD(ChiTietLichDayDTO ctld)
        {
            CHITIETLICHDAY ctlds = qlgv.CHITIETLICHDAYs.Where(t => t.MALICH == ctld.malich).FirstOrDefault();

            ctlds.MALICH = ctld.malich;
            ctlds.THU = ctld.thu;
            ctlds.NGAYDAY = ctld.ngayday;
            ctlds.TIETDAY = ctld.tietday;

            qlgv.SubmitChanges();
        }
    }
}
