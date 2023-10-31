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

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMa(string pMaSoCD, int pBac)
        {
            return bl_dal.getDataBacLuongTheoMa(pMaSoCD, pBac);
        }
    }
}
