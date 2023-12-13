using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChuNhiemBLL
    {
        ChuNhiemDAL cn_dal = new ChuNhiemDAL();

        public ChuNhiemBLL()
        {

        }

        //------------------ KIỂM TRA LỚP ĐÃ CÓ GIÁO VIÊN CHỦ NHIỆM CHƯA
        public bool isHomerooms(string pMaLP, string pNamHoc)
        {
            return cn_dal.isHomerooms(pMaLP, pNamHoc);
        }

        //------------------ THÊM CHỦ NHIỆM
        public void addCN(ChuNhiemDTO cn)
        {
            cn_dal.addCN(cn);
        }

        //------------------ XÓA CHỦ NHIỆM
        public bool removeCN(string pMaGV, string pMaLP, string pNamHoc)
        {
            return cn_dal.removeCN(pMaGV, pMaLP, pNamHoc);
        }

        //------------------ SỬA CHỦ NHIỆM
        public void editCN(ChuNhiemDTO cn)
        {
            cn_dal.editCN(cn);
        }

        //------------------ TÌM GIÁO VIÊN CHỮ NHIỆM HIỆN TẠI
        public ChuNhiemDTO findTeacherNow(string pMaLP, string pNamHoc)
        {
            return cn_dal.findTeacherNow(pMaLP, pNamHoc);
        }

        //------------------ KIỂM TRA GIÁO VIÊN CÓ LÀ CHỦ NHIỆM HAY KHÔNG
        public bool checkHomeroom(string pMaGV, string pNamHoc)
        {
            return cn_dal.checkHomeroom(pMaGV, pNamHoc);
        }

        //------------------ KIỂM TRA GIÁO VIÊN CÓ LÀ CHỦ NHIỆM LỚP KHUYẾT TẬT HAY KHÔNG
        public bool checkHomeroomKT(string pMaGV, string pNamHoc)
        {
            return cn_dal.checkHomeroomKT(pMaGV, pNamHoc);
        }
    }
}
