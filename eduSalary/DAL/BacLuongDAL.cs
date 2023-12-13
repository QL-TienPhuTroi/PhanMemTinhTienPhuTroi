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

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG
        public List<BacLuongDTO> getDataBacLuong()
        {
            var bacluongs = from bl in qlgv.BACLUONGs select new BacLuongDTO()
            {
                masocd = bl.MASOCD,
                bac = bl.BAC,
                hesoluong = (decimal)bl.HESOLUONG,
                mucluongcoso = (decimal)bl.MUCLUONGCOSO
            };

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMa(string pMaSoCD, int pBac)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD && bl.BAC == pBac select new BacLuongDTO()
            {
                masocd = bl.MASOCD,
                bac = bl.BAC,
                hesoluong = (decimal)bl.HESOLUONG,
                mucluongcoso = (decimal)bl.MUCLUONGCOSO
            };

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMaCD(string pMaSoCD)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD select new BacLuongDTO()
            {
                masocd = bl.MASOCD,
                bac = bl.BAC,
                hesoluong = (decimal)bl.HESOLUONG,
                mucluongcoso = (decimal)bl.MUCLUONGCOSO
            };

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }

        //------------------ LẤY MỨC LƯƠNG CƠ SỞ
        public decimal getMucLuongCoSo(string pMaSoCD, int pBac)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD && bl.BAC == pBac select bl.MUCLUONGCOSO;

            return (decimal)bacluongs.FirstOrDefault();
        }

        //------------------ LẤY HỆ SỐ LƯƠNG
        public decimal getHeSoLuong(string pMaSoCD, int pBac)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD && bl.BAC == pBac select bl.HESOLUONG;

            return (decimal)bacluongs.FirstOrDefault();
        }
    }
}
