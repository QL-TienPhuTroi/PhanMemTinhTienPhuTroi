using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LopHocDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public LopHocDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC
        public List<LopHocDTO> getDataLopHoc()
        {
            var lophocs = from lp in qlgv.LOPHOCs
                          orderby lp.TENLP
                          select new LopHocDTO()
                          {
                              malp = lp.MALP,
                              tenlp = lp.TENLP,
                              siso = (int)lp.SISO,
                              khiemkhuyet = (bool)lp.KHIEMKHUYET,
                              makhoi = (int)lp.MAKHOI,
                          };

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC THEO KHỐI
        public List<LopHocDTO> getDataLopHocTheoKhoi(string pValue)
        {
            var lophocs = from lp in qlgv.LOPHOCs
                          join khoi in qlgv.KHOIs on lp.MAKHOI equals khoi.MAKHOI
                          orderby lp.TENLP
                          where khoi.TENKHOI == pValue
                          select new LopHocDTO()
                          {
                              malp = lp.MALP,
                              tenlp = lp.TENLP,
                              siso = (int)lp.SISO,
                              makhoi = (int)lp.MAKHOI
                          };

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
        }

        //------------------ LẤY MÃ KHỐI CỦA LỚP
        public int getKhoi(string pMaLP)
        {
            var lophocs = from lp in qlgv.LOPHOCs
                          where lp.MALP == pMaLP
                          select lp.MAKHOI;

            return (int)lophocs.FirstOrDefault();
        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC THEO MÃ
        public List<LopHocDTO> getDataLopHocTheoMa(string pValue)
        {
            var lophocs = from lp in qlgv.LOPHOCs
                          where lp.MALP.Contains(pValue)
                          select new LopHocDTO()
                          {
                              malp = lp.MALP,
                              tenlp = lp.TENLP,
                              siso = (int)lp.SISO,
                              khiemkhuyet = (bool)lp.KHIEMKHUYET,
                              makhoi = (int)lp.MAKHOI
                          };

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
        }

        //------------------ THÊM LỚP
        public void addLP(LopHocDTO lp)
        {
            LOPHOC lps = new LOPHOC();

            lps.MALP = lp.malp;
            lps.TENLP = lp.tenlp;
            lps.SISO = lp.siso;
            lps.KHIEMKHUYET = lp.khiemkhuyet;
            lps.MAKHOI = lp.makhoi;


            qlgv.LOPHOCs.InsertOnSubmit(lps);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA LỚP
        public bool removeLP(string pMaLP)
        {
            try {
                LOPHOC lp = qlgv.LOPHOCs.Where(t => t.MALP == pMaLP).FirstOrDefault();
                if (lp != null)
                {
                    qlgv.LOPHOCs.DeleteOnSubmit(lp);
                    qlgv.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //------------------ SỬA LỚP
        public void editLP(LopHocDTO lp)
        {
            LOPHOC lps = qlgv.LOPHOCs.Where(t => t.MALP == lp.malp).FirstOrDefault();

            lps.MALP = lp.malp;
            lps.TENLP = lp.tenlp;
            lps.SISO = lp.siso;
            lps.KHIEMKHUYET = lp.khiemkhuyet;
            lps.MAKHOI = lp.makhoi;

            qlgv.SubmitChanges();
        }
        //------------------ TÌM LỚP HỌC
        public List<LopHocDTO> findDataLopHoc(string pValue)
        {
            var lophocs = from lp in qlgv.LOPHOCs
                          where lp.MALP.Contains(pValue) || lp.TENLP.Contains(pValue) || lp.SISO.ToString().Contains(pValue)

                          select new LopHocDTO()
                          {
                              malp = lp.MALP,
                              tenlp = lp.TENLP,
                              siso = (int)lp.SISO,
                              khiemkhuyet = (bool)lp.KHIEMKHUYET,
                              makhoi = (int)lp.MAKHOI,
                          };

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
        }
        //------------------ KIẾM TRA KHÓA CHÍNH
        public bool checkPK(string pMaLP)
        {
            var query = from lp in qlgv.LOPHOCs where lp.MALP == pMaLP select lp;
            return query.Any();
        }
    }
}
