using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class MonHocBLL
    {
        MonHocDAL mh_dal = new MonHocDAL();

        public MonHocBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN
        public List<MonHocDTO> getDataMonHoc()
        {
            return mh_dal.getDataMonHoc();
        }

        //------------------ LẤY DỮ LIỆU MÔN HỌC KHÔNG TỒN TẠI TRONG LỊCH DẠY
        public List<MonHocDTO> getDataMonHocKhongTonTai(string pMaLP, string pNamHoc)
        {
            return mh_dal.getDataMonHocKhongTonTai(pMaLP, pNamHoc);
        }
    }
}
