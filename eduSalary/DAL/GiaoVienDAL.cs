﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Runtime.Remoting.Contexts;

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
                macm = nv.MACM
            });

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN ĐƯỢC LỌC
        public List<GiaoVienLocDTO> getDataGiaoVienLoc()
        {
            var query = from gv in qlgv.GIAOVIENs select gv;

            var giaoviens = query.ToList().ConvertAll(nv => new GiaoVienLocDTO()
            {
                magv = nv.MAGV,
                hoten = nv.HOTEN,
                ngaysinh = (DateTime)nv.NGAYSINH,
                gioitinh = nv.GIOITINH,
            });

            List<GiaoVienLocDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ TÌM GIÁO VIÊN ĐƯỢC LỌC
        public List<GiaoVienLocDTO> findDataGiaoVienLoc(string pValue)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV.Contains(pValue) || gv.HOTEN.Contains(pValue) select gv;

            var giaoviens = query.ToList().ConvertAll(nv => new GiaoVienLocDTO() 
            {
                magv = nv.MAGV,
                hoten = nv.HOTEN,
                ngaysinh = (DateTime)nv.NGAYSINH,
                gioitinh = nv.GIOITINH,
            });

            List<GiaoVienLocDTO> lst_gv = giaoviens.ToList();

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
            });

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN KHÔNG TỒN TẠI TRONG CHỦ NHIỆM
        public List<GiaoVienDTO> getDataGiaoVienKhongTonTai(string pNamHoc)
        {
            var query = qlgv.GIAOVIENs.Where(gv => !qlgv.CHUNHIEMs.Any(cn => cn.MAGV == gv.MAGV && cn.NAMHOC == pNamHoc && cn.TRANGTHAI == true) && qlgv.CHITIETCHUCVUs.Any(ctcv => ctcv.MAGV == gv.MAGV && ctcv.MACV == 4));

            var giaoviens = query.ToList().ConvertAll(nv => new GiaoVienDTO()
            {
                magv = nv.MAGV,
                hoten = nv.HOTEN,
                ngaysinh = (DateTime)nv.NGAYSINH,
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
                macm = nv.MACM
            });

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY TÊN GIÁO VIÊN
        public string getNameGiaoVien(string pCode)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV == pCode select gv.HOTEN;
            string pHoTen = query.FirstOrDefault();
            return pHoTen;
        }

        //------------------ THÊM GIÁO VIÊN
        public void addGV(GiaoVienDTO gv)
        {
            GIAOVIEN gvs = new GIAOVIEN();

            gvs.MAGV = gv.magv;
            gvs.HOTEN = gv.hoten;
            gvs.NGAYSINH = gv.ngaysinh;
            gvs.GIOITINH = gv.gioitinh;
            gvs.DIACHI = gv.diachi;
            gvs.SODIENTHOAI = gv.sodienthoai;
            gvs.CCCD = gv.cccd;
            gvs.EMAIL = gv.email;
            gvs.NGAYVAOTRUONG = gv.ngayvaotruong;
            gvs.NGAYVAODANG = gv.ngayvaodang;
            gvs.DONVICONGTAC = gv.donvicongtac; 
            gvs.DANTOC = gv.dantoc;
            gvs.TONGIAO = gv.tongiao;
            gvs.THAMNIEN = gv.thamnien;
            gvs.MASOCD = gv.masocd;
            gvs.BAC = gv.bac;
            gvs.MACM = gv.macm;

            qlgv.GIAOVIENs.InsertOnSubmit(gvs);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA GIÁO VIÊN
        public bool removeGV(string pMaGV)
        {
            GIAOVIEN gv = qlgv.GIAOVIENs.Where(t => t.MAGV == pMaGV).FirstOrDefault();
            if (gv != null)
            {
                qlgv.GIAOVIENs.DeleteOnSubmit(gv);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA GIÁO VIÊN
        public void editGV(GiaoVienDTO gv)
        {
            GIAOVIEN gvs = qlgv.GIAOVIENs.Where(t => t.MAGV == gv.magv).FirstOrDefault();

            gvs.MAGV = gv.magv;
            gvs.HOTEN = gv.hoten;
            gvs.NGAYSINH = gv.ngaysinh;
            gvs.GIOITINH = gv.gioitinh;
            gvs.DIACHI = gv.diachi;
            gvs.SODIENTHOAI = gv.sodienthoai;
            gvs.CCCD = gv.cccd;
            gvs.EMAIL = gv.email;
            gvs.NGAYVAOTRUONG = gv.ngayvaotruong;
            gvs.NGAYVAODANG = gv.ngayvaodang;
            gvs.DONVICONGTAC = gv.donvicongtac;
            gvs.DANTOC = gv.dantoc;
            gvs.TONGIAO = gv.tongiao;
            gvs.THAMNIEN = gv.thamnien;
            gvs.MASOCD = gv.masocd;
            gvs.BAC = gv.bac;
            gvs.MACM = gv.macm;

            qlgv.SubmitChanges();
        }

        //------------------ KIỂM TRA GIỚI TÍNH GIÁO VIÊN
        public bool checkGenderTeacher(string pMaGV)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV == pMaGV && gv.GIOITINH == "Nam" select gv;
            return query.Any();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaGV)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV == pMaGV select gv;
            return query.Any();
        }
    }
}
