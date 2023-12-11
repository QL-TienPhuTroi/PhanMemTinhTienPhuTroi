using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class TaiKhoanDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public TaiKhoanDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU TÀI KHOẢN
        public List<TaiKhoanDTO> getDataTaiKhoan()
        {
            var taikhoans = from tk in qlgv.TAIKHOANs select new TaiKhoanDTO()
            {
                magv = tk.MAGV,
                matkhau = tk.MATKHAU,
                maqtc = tk.MAQTC
            };

            List<TaiKhoanDTO> lst_tk = taikhoans.ToList();

            return lst_tk;
        }

        //------------------ KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG
        public bool isSuccessLogin(string pCode, string pPass)
        {
            var query = from tk in qlgv.TAIKHOANs where tk.MAGV == pCode && tk.MATKHAU == pPass select tk;
            return query.Any();
        }

        //------------------ KIỂM TRA QUYỀN
        public int getRole (string pCode, string pPass)
        {
            var query = from tk in qlgv.TAIKHOANs where tk.MAGV == pCode && tk.MATKHAU == pPass select tk.MAQTC;
            return query.FirstOrDefault();
        }
    }
}
