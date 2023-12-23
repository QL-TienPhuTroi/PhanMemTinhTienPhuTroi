using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhoiBLL
    {
        KhoiDAL kh_dal = new KhoiDAL();
        public KhoiBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU KHỐI
        public List<KhoiDTO> getDataKhoi()
        {
            return kh_dal.getDataKhoi();
        }
        //------------------ LẤY DỮ LIỆU KHỐI
        public string getDataTenKhoiTheoMa(int pMaKhoi)
        {
            return kh_dal.getDataTenKhoiTheoMa(pMaKhoi);
        }
       
    }
}
