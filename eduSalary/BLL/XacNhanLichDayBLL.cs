using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class XacNhanLichDayBLL
    {
        XacNhanLichDayDAL xnld_dal = new XacNhanLichDayDAL();

        public XacNhanLichDayBLL()
        {
            
        }

        //------------------ THÊM XÁC NHẬN LỊCH DẠY
        public void addXNLD(XacNhanLichDayDTO xnld)
        {
            xnld_dal.addXNLD(xnld);
        }

        //------------------ XÓA XÁC NHẬN LỊCH DẠY
        public bool removeXNLDThu(string pMaLich, DateTime pNgayDay)
        {
            return xnld_dal.removeXNLDThu(pMaLich, pNgayDay);
        }

        //------------------ XÓA TXÁC NHẬN LỊCH DẠY
        public bool removeXNLD(string pMaLich, int pTietDay, DateTime pNgayDay)
        {
           return xnld_dal.removeXNLD(pMaLich, pTietDay, pNgayDay);
        }

        //------------------ XÓA TXÁC NHẬN LỊCH DẠY
        public bool removeXNLD(string pMaLich)
        {
            return xnld_dal.removeXNLD(pMaLich);
        }

        //------------------ XÓA TXÁC NHẬN LỊCH DẠY
        public bool removeXNLD(string pMaLich, int pTietDay)
        {
            return xnld_dal.removeXNLD(pMaLich, pTietDay);
        }

        //------------------ SỬA XÁC NHẬN LỊCH DẠY
        public void editXNLD(string pMaLich, int pTietDay, DateTime pNgayDay)
        {
            xnld_dal.editXNLD(pMaLich, pTietDay, pNgayDay);
        }

        //------------------ KIỂM TRA XÁC NHẬN
        public bool checkConfirm(string pMaLich, DateTime pNgayDay, int pTietDay)
        {
            return xnld_dal.checkConfirm(pMaLich, pNgayDay, pTietDay);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaLich, DateTime pNgayDay, int pTietDay)
        {
            return xnld_dal.checkPK(pMaLich, pNgayDay, pTietDay);
        }
    }
}
