using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChuyenMonDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ChuyenMonDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHUYÊN MÔN
        public List<ChuyenMonDTO> getDataChuyenMon()
        {
            var query = from cm in qlgv.CHUYENMONs select cm;

            var chuyenmons = query.ToList().ConvertAll(nv => new ChuyenMonDTO()
            {
                macm = nv.MACM,
                tencm = nv.TENCM
            });

            List<ChuyenMonDTO> lst_cm = chuyenmons.ToList();

            return lst_cm;
        }

        //------------------ LẤY DỮ LIỆU CHUYÊN MÔN THEO MÃ CHUYÊN MÔN
        public List<ChuyenMonDTO> getDataChuyenMonTheoMa(int pMaCM)
        {
            var query = from cm in qlgv.CHUYENMONs where cm.MACM == pMaCM select cm;

            var chuyenmons = query.ToList().ConvertAll(nv => new ChuyenMonDTO()
            {
                macm = nv.MACM,
                tencm = nv.TENCM
            });

            List<ChuyenMonDTO> lst_cm = chuyenmons.ToList();

            return lst_cm;
        }
    }
}
