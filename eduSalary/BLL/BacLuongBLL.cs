using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BacLuongBLL
    {
        BacLuongDAL bl_dal = new BacLuongDAL();

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG
        public List<BacLuongDTO> getDataBacLuong()
        {
            return bl_dal.getDataBacLuong();
        }

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMa(string pMaSoCD, int pBac)
        {
            return bl_dal.getDataBacLuongTheoMa(pMaSoCD, pBac);
        }

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMaCD(string pMaSoCD)
        {
            return bl_dal.getDataBacLuongTheoMaCD(pMaSoCD);
        }

        //------------------ LẤY MỨC LƯƠNG CƠ SỞ
        public decimal getMucLuongCoSo(string pMaSoCD, int pBac)
        {
            return bl_dal.getMucLuongCoSo(pMaSoCD, pBac);
        }

        //------------------ LẤY HỆ SỐ LƯƠNG
        public decimal getHeSoLuong(string pMaSoCD, int pBac)
        {
            return bl_dal.getHeSoLuong(pMaSoCD, pBac);
        }
    }
}
