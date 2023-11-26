using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using static System.Net.Mime.MediaTypeNames;

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

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN ĐƯỢC LỌC
        public List<GiaoVienLocDTO> getDataGiaoVienLoc()
        {
            return gv_dal.getDataGiaoVienLoc();
        }

        //------------------ TÌM GIÁO VIÊN ĐƯỢC LỌC
        public List<GiaoVienLocDTO> findDataGiaoVienLoc(string pValue)
        {
            return gv_dal.findDataGiaoVienLoc(pValue);
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN THEO MÃ GIÁO VIÊN
        public List<GiaoVienDTO> getDataGiaoVienTheoMa(string pMaGV)
        {
            return gv_dal.getDataGiaoVienTheoMa(pMaGV);
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN KHÔNG TỒN TẠI TRONG CHỦ NHIỆM
        public List<GiaoVienDTO> getDataGiaoVienKhongTonTai(string pNamHoc)
        {
            return gv_dal.getDataGiaoVienKhongTonTai(pNamHoc);
        }

        //------------------ LẤY TÊN GIÁO VIÊN
        public string getNameGiaoVien(string pCode)
        {
            return gv_dal.getNameGiaoVien(pCode);
        }

        //------------------ THÊM GIÁO VIÊN
        public void addGV(GiaoVienDTO gv)
        {
            gv_dal.addGV(gv);
        }

        //------------------ XÓA GIÁO VIÊN
        public bool removeGV(string pMaGV)
        {
            return gv_dal.removeGV(pMaGV);
        }

        //------------------ SỬA GIÁO VIÊN
        public void editGV(GiaoVienDTO gv)
        {
            gv_dal.editGV(gv); 
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaGV)
        {            
            return gv_dal.checkPK(pMaGV);
        }
    }
}
