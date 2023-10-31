using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChucDanhBLL
    {
        ChucDanhDAL cd_dal = new ChucDanhDAL();

        //------------------ LẤY DỮ LIỆU CHỨC DANH THEO MÃ SỐ CHỨC DANH
        public List<ChucDanhDTO> getDataChucDanhTheoMa(string pMaSoCD)
        {
            return cd_dal.getDataChucDanhTheoMa(pMaSoCD);
        }
    }
}
