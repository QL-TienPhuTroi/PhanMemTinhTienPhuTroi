using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChucVuBLL
    {
        ChucVuDAL cv_dal = new ChucVuDAL();

        //------------------ LẤY DỮ LIỆU CHỨC VỤ
        public List<ChucVuDTO> getDataChucVu()
        {
            return cv_dal.getDataChucVu();
        }
    }
}
