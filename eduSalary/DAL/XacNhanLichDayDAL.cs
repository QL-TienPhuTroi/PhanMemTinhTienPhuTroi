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

        //------------------ XÓA TXÁC NHẬN LỊCH DẠY
        public bool removeXNLD(string pMaLich)
        {
            var xnlds = qlgv.XACNHANLICHDAYs.Where(xnld => xnld.MALICH == pMaLich).ToList();

            if (xnlds != null)
            {
                foreach (var xnld in xnlds)
                {
                    qlgv.XACNHANLICHDAYs.DeleteOnSubmit(xnld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ XÓA XÁC NHẬN LỊCH DẠY
        public bool removeXNLD(string pMaLich, DateTime pNgayDay)
        {
            var xnlds = (from xnld in qlgv.XACNHANLICHDAYs where xnld.MALICH == pMaLich && xnld.NGAYDAY == pNgayDay select xnld).ToList();

            if (xnlds != null)
            {
                foreach (var xnld in xnlds)
                {
                    qlgv.XACNHANLICHDAYs.DeleteOnSubmit(xnld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ XÓA XÁC NHẬN LỊCH DẠY
        public bool removeXNLDThu(string pMaLich, DateTime pNgayDay)
        {
            var xnlds = (from xnld in qlgv.XACNHANLICHDAYs where xnld.MALICH == pMaLich && xnld.NGAYDAY.DayOfWeek == pNgayDay.DayOfWeek select xnld).ToList();

            if (xnlds != null)
            {
                foreach (var xnld in xnlds)
                {
                    qlgv.XACNHANLICHDAYs.DeleteOnSubmit(xnld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ XÓA XÁC NHẬN LỊCH DẠY
        public bool removeXNLD(string pMaLich, int pTietDay, DateTime pNgayDay)
        {
            var xnlds = (from xnld in qlgv.XACNHANLICHDAYs where xnld.MALICH == pMaLich && xnld.TIETDAY == pTietDay && xnld.NGAYDAY == pNgayDay select xnld).ToList();

            if (xnlds != null)
            {
                foreach (var xnld in xnlds)
                {
                    qlgv.XACNHANLICHDAYs.DeleteOnSubmit(xnld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ XÓA XÁC NHẬN LỊCH DẠY
        public bool removeXNLD(string pMaLich, int pTietDay)
        {
            var xnlds = qlgv.XACNHANLICHDAYs.Where(xnld => xnld.MALICH == pMaLich && xnld.TIETDAY == pTietDay).ToList();

            if (xnlds != null)
            {
                foreach (var xnld in xnlds)
                {
                    qlgv.XACNHANLICHDAYs.DeleteOnSubmit(xnld);
                }
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA XÁC NHẬN LỊCH DẠY
        public void editXNLD(string pMaLich, int pTietDay, DateTime pNgayDay)
        {
            XACNHANLICHDAY xnlds = (from xnld in qlgv.XACNHANLICHDAYs where xnld.MALICH == pMaLich && xnld.TIETDAY == pTietDay && xnld.NGAYDAY == pNgayDay select xnld).FirstOrDefault();

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
