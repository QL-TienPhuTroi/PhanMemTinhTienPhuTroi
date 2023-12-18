using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanDAL tk_dal = new TaiKhoanDAL();

        public TaiKhoanBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU TÀI KHOẢN
        public List<TaiKhoanDTO> getDataTaiKhoan()
        {
           return tk_dal.getDataTaiKhoan();
        }

        //------------------ KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG
        public bool isSuccessLogin(string pCode, string pPass)
        {
            return tk_dal.isSuccessLogin(pCode, pPass);
        }

        //------------------ THÊM TÀI KHOẢN
        public void addTK(TaiKhoanDTO tk)
        {
            tk_dal.addTK(tk);
        }

        //------------------ XÓA TÀI KHOẢN
        public bool removeTK(string pMaGV)
        {
            return tk_dal.removeTK(pMaGV);
        }

        //------------------ SỬA TÀI KHOẢN
        public void editTK(TaiKhoanDTO tk)
        {
            tk_dal.editTK(tk);
        }

        //------------------ KIỂM TRA QUYỀN
        public int getRole(string pCode, string pPass)
        {
            return tk_dal.getRole(pCode, pPass);
        }
    }
}
