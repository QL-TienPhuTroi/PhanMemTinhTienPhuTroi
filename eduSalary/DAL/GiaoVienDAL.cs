using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class GiaoVienDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public GiaoVienDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN
        public List<GiaoVienDTO> getDataGiaoVien()
        {
            var query = from gv in qlgv.GIAOVIENs select gv;

            var giaoviens = query.ToList().ConvertAll(nv => new GiaoVienDTO()
            {
                magv = nv.MAGV,
                hoten = nv.HOTEN,
                ngaysinh = (DateTime)nv.NGAYSINH,
                matkhau = nv.MATKHAU,
                gioitinh = nv.GIOITINH,
                diachi = nv.DIACHI,
                sodienthoai = nv.SODIENTHOAI,
                cccd = nv.CCCD,
                email = nv.EMAIL,
                ngayvaotruong = (DateTime)nv.NGAYVAOTRUONG,
                ngayvaodang = (DateTime)nv.NGAYVAODANG,
                donvicongtac = nv.DONVICONGTAC,
                dantoc = nv.DANTOC,
                tongiao = nv.TONGIAO,
                thamnien = (int)nv.THAMNIEN,
                masocd = nv.MASOCD,
                bac = nv.BAC,
                macm = nv.MACM,
                maqtc = nv.MAQTC
            });

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN THEO MÃ GIÁO VIÊN
        public List<GiaoVienDTO> getDataGiaoVienTheoMa(string pMaGV)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV == pMaGV select gv;

            var giaoviens = query.ToList().ConvertAll(nv => new GiaoVienDTO()
            {
                magv = nv.MAGV,
                hoten = nv.HOTEN,
                ngaysinh = (DateTime)nv.NGAYSINH,
                matkhau = nv.MATKHAU,
                gioitinh = nv.GIOITINH,
                diachi = nv.DIACHI,
                sodienthoai = nv.SODIENTHOAI,
                cccd = nv.CCCD,
                email = nv.EMAIL,
                ngayvaotruong = (DateTime)nv.NGAYVAOTRUONG,
                ngayvaodang = (DateTime)nv.NGAYVAODANG,
                donvicongtac = nv.DONVICONGTAC,
                dantoc = nv.DANTOC,
                tongiao = nv.TONGIAO,
                thamnien = (int)nv.THAMNIEN,
                masocd = nv.MASOCD,
                bac = nv.BAC,
                macm = nv.MACM,
                maqtc = nv.MAQTC
            });

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY TÊN GIÁO VIÊN
        public string getNameGiaoVien(string pCode, string pPass)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV == pCode && gv.MATKHAU == pPass select gv.HOTEN;
            string pHoTen = query.FirstOrDefault();
            return pHoTen;
        }

        //------------------ KIỂM TRA ĐĂNG NHẬP THÀNH CÔNG
        public bool isSuccessLogin(string pCode, string pPass)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV == pCode && gv.MATKHAU == pPass select gv;
            return query.Any();
        }
    }
}
