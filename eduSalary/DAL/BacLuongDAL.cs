using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BacLuongDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public BacLuongDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMa(string pMaSoCD, int pBac)
        {
            var query = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD && bl.BAC == pBac select bl;

            var bacluongs = query.ToList().ConvertAll(nv => new BacLuongDTO()
            {
                masocd = nv.MASOCD,
                bac = nv.BAC,
                hesoluong = (decimal)nv.HESOLUONG
            });

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }
    }
}
