using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DinhMucTietDayBLL
    {
        DInhMucTietDayDAL dmtd_dal = new DInhMucTietDayDAL();
        //------------------ LẤY DỮ LIỆU ĐỊNH MỨC TIẾT DẠY
        public List<DinhMucTietDayDTO> getDataDinhMucTietDay()
        {
            return dmtd_dal.getDataDinhMucTietDay();
        }
        //------------------ LẤY DỮ LIỆU ĐỊNH MỨC TIẾT DẠY THEO MÃ
        public List<DinhMucTietDayDTO> getDataDinhMucTietDayTheoMa(int pMaCV)
        {
            return dmtd_dal.getDataDinhMucTietDayTheoMa(pMaCV);
        }
        //------------------ LẤY DỮ LIỆU ĐỊNH MỨC TIẾT DẠY THEO MÃ VÀ SỐ DMTD
        public List<DinhMucTietDayDTO> getDataDinhMucTietDayTheoMaVaSoDMTD(int pMaCV, decimal pSoDMTD)
        {
            return dmtd_dal.getDataDinhMucTietDayTheoMaVaSoDMTD(pMaCV, pSoDMTD);
        }
        //------------------ THÊM ĐỊNH MỨC TIẾT DẠY
        public void addDMTD(DinhMucTietDayDTO dmtd)
        {
            dmtd_dal.addDMTD(dmtd);
        }
        //------------------ TÌM ĐỊNH MỨC TIẾT DẠY ĐƯỢC LỌC
        public List<DinhMucTietDayDTO> findDataDinhMucTietDayLoc(string pValue)
        {
            return dmtd_dal.findDataDinhMucTietDayLoc(pValue);
        }
        //------------------ XÓA ĐỊNH MỨC TIẾT DẠY
        public bool removeDMTD(int pMaCV, decimal pSoDMTD)
        {
            return dmtd_dal.removeDMTD(pMaCV, pSoDMTD);
        }

        //------------------ SỬA ĐỊNH MỨC TIẾT DẠY
        public void editDMTD(DinhMucTietDayDTO dmtd)
        {
            dmtd_dal.editDMTD(dmtd);
        }
        //------------------ KIẾM TRA KHÓA CHÍNH
        public bool checkPK(int pMaCV)
        {
            return dmtd_dal.checkPK(pMaCV);
        }
    }
}
