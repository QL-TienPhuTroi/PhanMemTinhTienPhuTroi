using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;
using System.Text.RegularExpressions;

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
            var chitietlichdays = from ctld in qlgv.CHITIETLICHDAYs
                                  select new ChiTietLichDayDTO()
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
            var chitietlichdays = from ctld in qlgv.CHITIETLICHDAYs
                                  where ctld.MALICH == pMaLich
                                  select new ChiTietLichDayDTO()
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

        //------------------ TÌM NGÀY ĐẦU TUẦN
        public DateTime FindStartOfWeek(DateTime ngayBatKy)
        {
            int daysToSubtract = ((int)ngayBatKy.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;

            DateTime firstDayOfWeek = ngayBatKy.Date.AddDays(-daysToSubtract);

            return firstDayOfWeek;
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 TUẦN CỦA GIÁO VIÊN
        public int getCountLessonInWeek(string pMaGV, DateTime pNgayDauTuan, string pNamHoc)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs 
                        join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH 
                        where ld.MAGV == pMaGV && ctld.NGAYDAY >= pNgayDauTuan && ctld.NGAYDAY <= pNgayDauTuan.AddDays(6) && ld.NAMHOC == pNamHoc 
                        select ctld;
            return query.Count();
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 TUẦN CỦA GIÁO VIÊN DẠY MÔN HỌC CỤ THỂ
        public int getCountLessonInWeek(string pMaGV, DateTime pNgayDauTuan, string pNamHoc, int pMaMH, string pMaLop)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs 
                        join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH 
                        where ld.MAGV == pMaGV && ctld.NGAYDAY >= pNgayDauTuan && ctld.NGAYDAY <= pNgayDauTuan.AddDays(6) && ld.NAMHOC == pNamHoc && ld.MAMH == pMaMH && ld.MALP == pMaLop
                        select ctld;
            return query.Count();
        }

        //------------------ ĐẾM SỐ TIẾT ĐÃ DẠY TRONG 1 NĂM HỌC CỦA GIÁO VIÊN
        public int getCountLessonTeachingInWeek(string pMaGV, DateTime pNgayDauTuan, string pNamHoc)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs
                        join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH
                        join xnld in qlgv.XACNHANLICHDAYs
                            on new { ctld.MALICH, ctld.TIETDAY, ctld.NGAYDAY }
                            equals new { xnld.MALICH, xnld.TIETDAY, xnld.NGAYDAY }
                        where ld.MAGV == pMaGV && xnld.HOANTHANH == true && ld.NAMHOC == pNamHoc && ctld.NGAYDAY >= pNgayDauTuan && ctld.NGAYDAY <= pNgayDauTuan.AddDays(6)
                        select ctld;
            return query.Count();
        }

        //------------------ ĐẾM SỐ TIẾT TRONG 1 NĂM HỌC CỦA GIÁO VIÊN
        public int getCountLessonInYear(string pMaGV, string pNamHoc)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH where ld.MAGV == pMaGV && ld.NAMHOC == pNamHoc select ctld;
            return query.Count();
        }

        //------------------ ĐẾM SỐ TIẾT ĐÃ DẠY TRONG 1 NĂM HỌC CỦA GIÁO VIÊN
        public int getCountLessonTeachingInYear(string pMaGV, string pNamHoc)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs
                        join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH
                        join xnld in qlgv.XACNHANLICHDAYs
                            on new { ctld.MALICH, ctld.TIETDAY, ctld.NGAYDAY }
                            equals new { xnld.MALICH, xnld.TIETDAY, xnld.NGAYDAY }
                        where ld.MAGV == pMaGV && xnld.HOANTHANH == true && ld.NAMHOC == pNamHoc
                        select ctld;
            return query.Count();
        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY THEO NGÀY
        public List<ChiTietLichDayLocDTO> getDataLessonDaily(DateTime pNgayDay)
        {
            var chitietlichdays = from ctld in qlgv.CHITIETLICHDAYs
                                  join ld in qlgv.LICHDAYs on ctld.MALICH equals ld.MALICH
                                  join gv in qlgv.GIAOVIENs on ld.MAGV equals gv.MAGV
                                  join mh in qlgv.MONHOCs on ld.MAMH equals mh.MAMH
                                  join lp in qlgv.LOPHOCs on ld.MALP equals lp.MALP
                                  join xnld in qlgv.XACNHANLICHDAYs
                                    on new { ctld.MALICH, ctld.TIETDAY, ctld.NGAYDAY }
                                    equals new { xnld.MALICH, xnld.TIETDAY, xnld.NGAYDAY }
                                  where ctld.NGAYDAY == pNgayDay
                                  select new ChiTietLichDayLocDTO()
                                  {
                                      malich = ctld.MALICH,
                                      magv = ld.MAGV,
                                      hoten = gv.HOTEN,
                                      tenmh = mh.TENMH,
                                      tenlp = lp.TENLP,
                                      tietday = ctld.TIETDAY,
                                      ngayday = (DateTime)ctld.NGAYDAY,
                                      hoanthanh = (bool)xnld.HOANTHANH,
                                  };

            List<ChiTietLichDayLocDTO> lst_ctld = chitietlichdays.ToList();

            return lst_ctld;
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
        public bool removeCTLD(string pMaLich)
        {
            var ctlds = qlgv.CHITIETLICHDAYs.Where(t => t.MALICH == pMaLich).ToList();

            if (ctlds != null)
            {
                foreach (var ctld in ctlds)
                {
                    qlgv.CHITIETLICHDAYs.DeleteOnSubmit(ctld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ XÓA CHI TIẾT LỊCH DẠY
        public bool removeCTLD(string pMaLich, DateTime pNgayDay)
        {
            var ctlds = qlgv.CHITIETLICHDAYs.Where(t => t.MALICH == pMaLich && t.NGAYDAY == pNgayDay).ToList();

            if (ctlds != null)
            {
                foreach (var ctld in ctlds)
                {
                    qlgv.CHITIETLICHDAYs.DeleteOnSubmit(ctld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ XÓA CHI TIẾT LỊCH DẠY
        public bool removeCTLD(string pMaLich, string pThu)
        {
            var ctlds = qlgv.CHITIETLICHDAYs.Where(t => t.MALICH == pMaLich && t.THU == pThu).ToList();

            if (ctlds != null)
            {
                foreach (var ctld in ctlds)
                {
                    qlgv.CHITIETLICHDAYs.DeleteOnSubmit(ctld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
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
