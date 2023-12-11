using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //------------------ LẤY DỮ LIỆU CHI TIẾT LỊCH DẠY THEO MÃ LỊCH
        public bool checkTrungLich(DateTime pNgayDay, int pTietDay)
        {
            return ctld_dal.checkTrungLich(pNgayDay, pTietDay);
        }

        //------------------ THÊM CHI TIẾT LỊCH DẠY
        public void addCTLD(ChiTietLichDayDTO ctld)
        {
            ctld_dal.addCTLD(ctld);
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
