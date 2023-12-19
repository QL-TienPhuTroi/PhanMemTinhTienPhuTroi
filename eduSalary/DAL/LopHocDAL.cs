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
            var lophocs = from lp in qlgv.LOPHOCs orderby lp.TENLP select new LopHocDTO()
            {
                malp = lp.MALP,
                tenlp = lp.TENLP,
                siso = (int)lp.SISO,
                khiemkhuyet = (bool)lp.KHIEMKHUYET
            };

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC THEO KHỐI
        public List<LopHocDTO> getDataLopHocTheoKhoi(string pValue)
        {
            var lophocs = from lp in qlgv.LOPHOCs orderby lp.TENLP where lp.TENLP.Contains(pValue) select new LopHocDTO()
            {
                malp = lp.MALP,
                tenlp = lp.TENLP,
                siso = (int)lp.SISO,
                khiemkhuyet = (bool)lp.KHIEMKHUYET
            };

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
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
                              khiemkhuyet = (bool)lp.KHIEMKHUYET
                          };

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
        }
        //------------------ KIỂM TRA LỚP KHUYÊT TẬT
        public bool isDisabilities(string pMaLP)
        {
            var query = from lp in qlgv.LOPHOCs where lp.MALP == pMaLP && lp.KHIEMKHUYET == true select lp;

            return query.Any();
        }
        //------------------ THÊM LỚP
        public void addLP(LopHocDTO lp)
        {
            LOPHOC lps = new LOPHOC();

            lps.MALP = lp.malp;
            lps.TENLP = lp.tenlp;
            lps.SISO = lp.siso;
            lps.KHIEMKHUYET = lp.khiemkhuyet;
            

            qlgv.LOPHOCs.InsertOnSubmit(lps);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA LỚP
        public bool removeLP(string pMaLP)
        {
            LOPHOC lp = qlgv.LOPHOCs.Where(t => t.MALP == pMaLP).FirstOrDefault();
            if (lp != null)
            {
                qlgv.LOPHOCs.DeleteOnSubmit(lp);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA LỚP
        public void editLP(LopHocDTO lp)
        {
            LOPHOC lps = qlgv.LOPHOCs.Where(t => t.MALP == lp.malp).FirstOrDefault();

            lps.MALP = lp.malp;
            lps.TENLP = lp.tenlp;
            lps.SISO = lp.siso;
            lps.KHIEMKHUYET = lp.khiemkhuyet;

            qlgv.SubmitChanges();
        }
        //------------------ TÌM LỚP HỌC
        public List<LopHocDTO> findDataLopHoc(string pValue)
        {
            var lophocs = from lp in qlgv.LOPHOCs
                            where lp.MALP.Contains(pValue) || lp.TENLP.Contains(pValue) || lp.SISO.ToString().Contains(pValue) || lp.KHIEMKHUYET.ToString().Contains(pValue)

                            select new LopHocDTO()
                            {
                                malp = lp.MALP,
                                tenlp = lp.TENLP,
                                siso = (int)lp.SISO,
                                khiemkhuyet = (bool)lp.KHIEMKHUYET,
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
