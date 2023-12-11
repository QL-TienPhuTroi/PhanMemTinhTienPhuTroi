using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LichDayBLL
    {
        LichDayDAL ld_dal = new LichDayDAL();

        public LichDayBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY
        public List<LichDayDTO> getDataLichDay()
        {
            return ld_dal.getDataLichDay();
        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY THEO LỚP
        public List<LichDayDTO> getDataLichDayTheoLop(string pMaLP, string pNamHoc)
        {
            return ld_dal.getDataLichDayTheoLop(pMaLP, pNamHoc);
        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY LỌC THEO LỚP
        public List<LichDayLocDTO> getDataLichDayLocTheoLop(string pMaLP, string pNamHoc)
        {
            return ld_dal.getDataLichDayLocTheoLop(pMaLP, pNamHoc);
        }

        //------------------ THÊM LỊCH DẠY
        public void addLD(LichDayDTO ld)
        {
            ld_dal.addLD(ld);
        }

        //------------------ XÓA LỊCH DẠY
        public bool removeLD(string pMaLich)
        {
            return ld_dal.removeLD(pMaLich);
        }

        //------------------ SỬA LỊCH DẠY
        public void editLD(LichDayDTO ld)
        {
            ld_dal.editLD(ld);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaLD)
        {
            return ld_dal.checkPK(pMaLD);
        }
    }
}
