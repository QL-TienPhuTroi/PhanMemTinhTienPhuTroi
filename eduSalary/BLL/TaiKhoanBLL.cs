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

        //------------------ KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG
        public bool isSuccessLogin(string pCode, string pPass)
        {
            return tk_dal.isSuccessLogin(pCode, pPass);
        }

        //------------------ KIỂM TRA QUYỀN
        public int getRole(string pCode, string pPass)
        {
            return tk_dal.getRole(pCode, pPass);
        }
    }
}
