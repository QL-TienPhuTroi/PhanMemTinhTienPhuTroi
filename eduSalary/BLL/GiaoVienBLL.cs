using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class GiaoVienBLL
    {
        GiaoVienDAL gv_dal = new GiaoVienDAL();

        public GiaoVienBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN
        public List<GiaoVienDTO> getDataGiaoVien()
        {
            return gv_dal.getDataGiaoVien();
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN THEO MÃ GIÁO VIÊN
        public List<GiaoVienDTO> getDataGiaoVienTheoMa(string pMaGV)
        {
            return gv_dal.getDataGiaoVienTheoMa(pMaGV);
        }

        //------------------ LẤY TÊN GIÁO VIÊN
        public string getNameGiaoVien(string pCode, string pPass)
        {
            return gv_dal.getNameGiaoVien(pCode, pPass);
        }

        //------------------ KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG
        public bool isSuccessLogin(string pCode, string pPass)
        {
            return gv_dal.isSuccessLogin(pCode, pPass);
        }
    }
}
