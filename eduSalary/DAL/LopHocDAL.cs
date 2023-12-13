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

        //------------------ KIỂM TRA LỚP KHUYÊT TẬT
        public bool isDisabilities()
        {
            var query = from lp in qlgv.LOPHOCs where lp.KHIEMKHUYET == true select lp;

            return query.Any();
        }
    }
}
