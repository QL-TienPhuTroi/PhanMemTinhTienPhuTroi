using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChucDanhDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ChucDanhDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHỨC DANH
        public List<ChucDanhDTO> getDataChucDanh()
        {
            var chucdanhs = from cd in qlgv.CHUCDANHNNs select new ChucDanhDTO()
            {
                masocd = cd.MASOCD,
                hangcd = cd.HANGCD
            };

            List<ChucDanhDTO> lst_cd = chucdanhs.ToList();

            return lst_cd;
        }

        //------------------ LẤY DỮ LIỆU CHỨC DANH THEO MÃ SỐ CHỨC DANH
        public List<ChucDanhDTO> getDataChucDanhTheoMa(string pMaSoCD)
        {
            var chucdanhs = from cd in qlgv.CHUCDANHNNs where cd.MASOCD == pMaSoCD select new ChucDanhDTO()
            {
                masocd = cd.MASOCD,
                hangcd = cd.HANGCD
            };

            List<ChucDanhDTO> lst_cd = chucdanhs.ToList();

            return lst_cd;
        }
    }
}
