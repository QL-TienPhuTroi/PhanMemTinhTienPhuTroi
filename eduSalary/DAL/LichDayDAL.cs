using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LichDayDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public LichDayDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY
        public List<LichDayDTO> getDataLichDay()
        {
            var lichdays = from ld in qlgv.LICHDAYs select new LichDayDTO()
            {
                malich = ld.MALICH,
                magv = ld.MAGV,
                mamh = ld.MAMH,
                malp = ld.MALP,
                thoigianbatdau = (DateTime)ld.THOIGIANBATDAU,
                thoigianketthuc = (DateTime)ld.THOIGIANKETTHUC,
                namhoc = ld.NAMHOC
            };

            List<LichDayDTO> lst_ld = lichdays.ToList();

            return lst_ld;
        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY THEO LỚP
        public List<LichDayDTO> getDataLichDayTheoLop(string pMaLP, string pNamHoc)
        {
            var lichdays = from ld in qlgv.LICHDAYs where ld.MALP == pMaLP && ld.NAMHOC == pNamHoc select new LichDayDTO()
            {
                malich = ld.MALICH,
                magv = ld.MAGV,
                mamh = ld.MAMH,
                malp = ld.MALP,
                thoigianbatdau = (DateTime)ld.THOIGIANBATDAU,
                thoigianketthuc = (DateTime)ld.THOIGIANKETTHUC,
                namhoc = ld.NAMHOC
            };

            List<LichDayDTO> lst_ld = lichdays.ToList();

            return lst_ld;
        }

        //------------------ LẤY DỮ LIỆU LỊCH DẠY LỌC THEO LỚP
        public List<LichDayLocDTO> getDataLichDayLocTheoLop(string pMaLP, string pNamHoc)
        {
            var lichdays = from ld in qlgv.LICHDAYs join mh in qlgv.MONHOCs on ld.MAMH equals mh.MAMH where ld.MALP == pMaLP && ld.NAMHOC == pNamHoc select new LichDayLocDTO()
            {
                malich = ld.MALICH,
                magv = ld.MAGV,
                tenmh = mh.TENMH,
                malp = ld.MALP,
                thoigianbatdau = (DateTime)ld.THOIGIANBATDAU,
                thoigianketthuc = (DateTime)ld.THOIGIANKETTHUC,
                namhoc = ld.NAMHOC
            };

            List<LichDayLocDTO> lst_ld = lichdays.ToList();

            return lst_ld;
        }

        //------------------ THÊM LỊCH DẠY
        public void addLD(LichDayDTO ld)
        {
            LICHDAY lds = new LICHDAY();

            lds.MALICH = ld.malich;
            lds.MAGV = ld.magv;
            lds.MAMH = ld.mamh;
            lds.MALP = ld.malp;
            lds.THOIGIANBATDAU = ld.thoigianbatdau;
            lds.THOIGIANKETTHUC = ld.thoigianketthuc;
            lds.NAMHOC = ld.namhoc;

            qlgv.LICHDAYs.InsertOnSubmit(lds);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA LỊCH DẠY
        public bool removeLD(string pMaLich)
        {
            LICHDAY ld = qlgv.LICHDAYs.Where(t => t.MALICH == pMaLich).FirstOrDefault();
            if (ld != null)
            {
                qlgv.LICHDAYs.DeleteOnSubmit(ld);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA LỊCH DẠY
        public void editLD(LichDayDTO ld)
        {
            LICHDAY lds = qlgv.LICHDAYs.Where(t => t.MALICH == ld.malich).FirstOrDefault();

            lds.MALICH = ld.malich;
            lds.MAGV = ld.magv;
            lds.MAMH = ld.mamh;
            lds.MALP = ld.malp;
            lds.THOIGIANBATDAU = ld.thoigianbatdau;
            lds.THOIGIANKETTHUC = ld.thoigianketthuc;
            lds.NAMHOC = ld.namhoc;

            qlgv.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaLD)
        {
            var query = from ld in qlgv.LICHDAYs where ld.MALICH == pMaLD select ld;
            return query.Any();
        }
    }
}
