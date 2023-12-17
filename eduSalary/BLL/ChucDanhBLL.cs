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

        //------------------ LẤY DỮ LIỆU CHỨC DANH
        public List<ChucDanhDTO> getDataChucDanh()
        {
            return cd_dal.getDataChucDanh();
        }

        //------------------ LẤY DỮ LIỆU CHỨC DANH THEO MÃ SỐ CHỨC DANH
        public List<ChucDanhDTO> getDataChucDanhTheoMa(string pMaSoCD)
        {
            return cd_dal.getDataChucDanhTheoMa(pMaSoCD);
        }
        //------------------ TÌM CHỨC DANH ĐƯỢC LỌC
        public List<ChucDanhDTO> findDataChucDanhNNLoc(string pValue)
        {
            return cd_dal.findDataChucDanhNNLoc(pValue);
        }
    }
}
