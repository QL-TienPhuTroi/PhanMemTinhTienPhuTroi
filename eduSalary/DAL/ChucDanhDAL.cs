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

        //------------------ LẤY DỮ LIỆU CHỨC DANH THEO MÃ SỐ CHỨC DANH
        public List<ChucDanhDTO> getDataChucDanhTheoMa(string pMaSoCD)
        {
            var query = from cd in qlgv.CHUCDANHs where cd.MASOCD == pMaSoCD select cd;

            var chucdanhs = query.ToList().ConvertAll(nv => new ChucDanhDTO()
            {
                masocd = nv.MASOCD,
                hangcd = nv.HANGCD
            });

            List<ChucDanhDTO> lst_cd = chucdanhs.ToList();

            return lst_cd;
        }
    }
}
