using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietChucVuDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ChiTietChucVuDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT CHỨC VỤ
        public List<ChiTietChucVuDTO> getDataChiTietChucVu()
        {
            var chucvus = from ctcv in qlgv.CHITIETCHUCVUs
                            select new ChiTietChucVuDTO()
                            {
                                magv = ctcv.MAGV,
                                macv = ctcv.MACV,
                                namhoc = ctcv.NAMHOC
                            };

            List<ChiTietChucVuDTO> lst_ctcv = chucvus.ToList();

            return lst_ctcv;
        }

        //------------------ THÊM CHI TIẾT CHỨC VỤ
        public void addCTCV(ChiTietChucVuDTO ctcv)
        {
            CHITIETCHUCVU ctcvs = new CHITIETCHUCVU();

            ctcvs.MAGV = ctcv.magv;
            ctcvs.MACV = ctcv.macv;
            ctcvs.NAMHOC = ctcv.namhoc;

            qlgv.CHITIETCHUCVUs.InsertOnSubmit(ctcvs);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA CHI TIẾT CHỨC VỤ
        public bool removeCTCV(string pMaGV)
        {
            CHITIETCHUCVU ctcvs = qlgv.CHITIETCHUCVUs.Where(t => t.MAGV == pMaGV).FirstOrDefault();

            if (ctcvs != null)
            {
                qlgv.CHITIETCHUCVUs.DeleteOnSubmit(ctcvs);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA CHI TIẾT CHỨC VỤ
        public void editCTCV(ChiTietChucVuDTO ctcv)
        {
            CHITIETCHUCVU ctcvs = qlgv.CHITIETCHUCVUs.Where(t => t.MAGV == ctcv.magv).FirstOrDefault();

            ctcvs.MAGV = ctcv.magv;
            ctcvs.MACV = ctcv.macv;
            ctcvs.NAMHOC = ctcv.namhoc;


            qlgv.SubmitChanges();
        }
    }
}
