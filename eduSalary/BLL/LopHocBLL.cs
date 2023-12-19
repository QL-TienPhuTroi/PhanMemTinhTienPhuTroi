using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LopHocBLL
    {
        LopHocDAL lp_dal = new LopHocDAL();

        public LopHocBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC
        public List<LopHocDTO> getDataLopHoc()
        {
            return lp_dal.getDataLopHoc();
        }

        //------------------ LẤY DỮ LIỆU LỚP HỌC THEO KHỐI
        public List<LopHocDTO> getDataLopHocTheoKhoi(string pValue)
        {
            return lp_dal.getDataLopHocTheoKhoi(pValue);
        }
        //------------------ LẤY DỮ LIỆU LỚP HỌC THEO MÃ
        public List<LopHocDTO> getDataLopHocTheoMa(string pValue)
        {
            return lp_dal.getDataLopHocTheoMa(pValue);
        }
        //------------------ KIỂM TRA LỚP KHUYÊT TẬT
        public bool isDisabilities(string pMaLP)
        {
            return lp_dal.isDisabilities(pMaLP);
        }
        //------------------ THÊM LỚP
        public void addLP(LopHocDTO lp)
        {
            lp_dal.addLP(lp);
        }

        //------------------ XÓA LỚP 
        public bool removeLP(string pMaLP)
        {
            return lp_dal.removeLP(pMaLP);
        }

        //------------------ SỬA LỚP
        public void editLP(LopHocDTO lp)
        {
            lp_dal.editLP(lp);
        }
        //------------------ TÌM LỚP
        public List<LopHocDTO> findDataLopHoc(string pValue)
        {
            return lp_dal.findDataLopHoc(pValue);
        }
        //------------------ KTKC
        public bool checkPK(string pMaLP)
        {
            return lp_dal.checkPK(pMaLP);
        }

    }
}
