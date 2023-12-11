using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThoiGianDayBLL
    {
        ThoiGianDayDAL tgd_dal = new ThoiGianDayDAL();

        public ThoiGianDayBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU THỜI GIAN DẠY
        public List<ThoiGianDayDTO> getDataThoiGianDay()
        {
            return tgd_dal.getDataThoiGianDay();
        }
    }
}
