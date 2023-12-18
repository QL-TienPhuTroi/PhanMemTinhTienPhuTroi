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

        //------------------ THÊM GIÁO VIÊN
        public void addTK(TaiKhoanDTO tk)
        {
            TAIKHOAN tks = new TAIKHOAN();

            tks.MAGV = tk.magv;
            tks.MATKHAU = tk.matkhau;
            tks.MAQTC = tk.maqtc;

            qlgv.TAIKHOANs.InsertOnSubmit(tks);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA TÀI KHOẢN
        public bool removeTK(string pMaGV)
        {
            TAIKHOAN tks = qlgv.TAIKHOANs.Where(t => t.MAGV == pMaGV).FirstOrDefault();

            if (tks != null)
            {
                qlgv.TAIKHOANs.DeleteOnSubmit(tks);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA TÀI KHOẢN
        public void editTK(TaiKhoanDTO tk)
        {
            TAIKHOAN tks = qlgv.TAIKHOANs.Where(t => t.MAGV == tk.magv).FirstOrDefault();

            tks.MAGV = tk.magv;
            tks.MATKHAU = tk.matkhau;
            tks.MAQTC = tk.maqtc;

            qlgv.SubmitChanges();
        }

        //------------------ KIỂM TRA QUYỀN
        public int getRole (string pCode, string pPass)
        {
            var query = from tk in qlgv.TAIKHOANs where tk.MAGV == pCode && tk.MATKHAU == pPass select tk.MAQTC;
            return query.FirstOrDefault();
        }
    }
}
