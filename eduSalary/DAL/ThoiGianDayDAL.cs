using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThoiGianDayDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ThoiGianDayDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU THỜI GIAN DẠY
        public List<ThoiGianDayDTO> getDataThoiGianDay()
        {
            var thoigiandays = from tgd in qlgv.THOIGIANDAYs select new ThoiGianDayDTO()
            {
                matg = tgd.MATG,
                tentiet = (int)tgd.TENTIET,
                giobatdau = (TimeSpan)tgd.GIOBATDAU,
                gioketthuc = (TimeSpan)tgd.GIOKETTHUC
            };

            List<ThoiGianDayDTO> lst_tgd = thoigiandays.ToList();

            return lst_tgd;
        }
    }
}
