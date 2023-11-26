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
            var query = from lp in qlgv.LOPHOCs orderby lp.TENLP select lp;

            var lophocs = query.ToList().ConvertAll(lp => new LopHocDTO()
            {
                malp = lp.MALP,
                tenlp = lp.TENLP,
                siso = (int)lp.SISO,
                khiemkhuyet = (bool)lp.KHIEMKHUYET
            });

            List<LopHocDTO> lst_lp = lophocs.ToList();

            return lst_lp;
        }
    }
}
