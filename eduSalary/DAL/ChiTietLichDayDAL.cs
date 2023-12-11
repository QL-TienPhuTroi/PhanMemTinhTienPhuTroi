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

        //------------------ LẤY DỮ LIỆU CHI TIẾT LỊCH DẠY THEO MÃ LỊCH
        public bool checkTrungLich(DateTime pNgayDay, int pTietDay)
        {
            var query = from ctld in qlgv.CHITIETLICHDAYs where ctld.NGAYDAY == pNgayDay && ctld.TIETDAY == pTietDay select ctld;
            return query.Any();
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
