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
            var chuyenmons = from cm in qlgv.CHUYENMONs select new ChuyenMonDTO()
            {
                macm = cm.MACM,
                tencm = cm.TENCM
            };

            List<ChuyenMonDTO> lst_cm = chuyenmons.ToList();

            return lst_cm;
        }

        //------------------ LẤY DỮ LIỆU CHUYÊN MÔN THEO MÃ CHUYÊN MÔN
        public List<ChuyenMonDTO> getDataChuyenMonTheoMa(int pMaCM)
        {
            var chuyenmons = from cm in qlgv.CHUYENMONs  where cm.MACM == pMaCM select new ChuyenMonDTO()
            {
                macm = cm.MACM,
                tencm = cm.TENCM
            };

            List<ChuyenMonDTO> lst_cm = chuyenmons.ToList();

            return lst_cm;
        }
        //------------------ LẤY DỮ LIỆU CHUYÊN MÔN THEO MÃ
        public string getDataCHuyenMonTheoMaCM(int pMaCM)
        {
            var chuyenmons = from kh in qlgv.CHUYENMONs
                        where kh.MACM == pMaCM
                        select kh.TENCM;

            return chuyenmons.FirstOrDefault();
        }
    }
}
