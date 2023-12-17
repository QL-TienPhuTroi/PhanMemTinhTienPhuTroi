using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class XacNhanLichDayDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public XacNhanLichDayDAL()
        {

        }

        //------------------ THÊM XÁC NHẬN LỊCH DẠY
        public void addXNLD(XacNhanLichDayDTO xnld)
        {
            XACNHANLICHDAY xnlds = new XACNHANLICHDAY();

            xnlds.MALICH = xnld.malich;
            xnlds.NGAYDAY = xnld.ngayday;
            xnlds.TIETDAY = xnld.tietday;
            xnlds.HOANTHANH = xnld.hoanthanh;

            qlgv.XACNHANLICHDAYs.InsertOnSubmit(xnlds);
            qlgv.SubmitChanges();
        }

        //------------------ SỬA XÁC NHẬN LỊCH DẠY
        public void editXNLD(string pMaLich, int pTietDay, DateTime pNgayDay)
        {
            XACNHANLICHDAY xnlds = (XACNHANLICHDAY)(from xnld in qlgv.XACNHANLICHDAYs where xnld.MALICH == pMaLich && xnld.TIETDAY == pTietDay && xnld.NGAYDAY == pNgayDay select xnld).SingleOrDefault();

            xnlds.HOANTHANH = true;

            qlgv.SubmitChanges();
        }

        //------------------ KIỂM TRA XÁC NHẬN
        public bool checkConfirm(string pMaLich, DateTime pNgayDay, int pTietDay)
        {
            var query = from xnld in qlgv.XACNHANLICHDAYs
                        where xnld.MALICH == pMaLich && xnld.NGAYDAY == pNgayDay && xnld.TIETDAY == pTietDay && xnld.HOANTHANH == true
                        select xnld;
            return query.Any();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaLich, DateTime pNgayDay, int pTietDay)
        {
            var query = from xnld in qlgv.XACNHANLICHDAYs where xnld.MALICH == pMaLich && xnld.NGAYDAY == pNgayDay && xnld.TIETDAY == pTietDay select xnld;
            return query.Any();
        }
    }
}
