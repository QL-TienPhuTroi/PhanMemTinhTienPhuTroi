using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Runtime.Remoting.Contexts;
using static System.Net.Mime.MediaTypeNames;

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
            var giaoviens = from gv in qlgv.GIAOVIENs where gv.TRANGTHAI == true select new GiaoVienDTO()
            {
                magv = gv.MAGV,
                trangthai = (bool)gv.TRANGTHAI,
                hoten = gv.HOTEN,
                ngaysinh = (DateTime)gv.NGAYSINH,
                gioitinh = gv.GIOITINH,
                diachi = gv.DIACHI,
                sodienthoai = gv.SODIENTHOAI,
                cccd = gv.CCCD,
                email = gv.EMAIL,
                ngayvaotruong = (DateTime)gv.NGAYVAOTRUONG,
                ngayvaodang = (DateTime)gv.NGAYVAODANG,
                donvicongtac = gv.DONVICONGTAC,
                dantoc = gv.DANTOC,
                tongiao = gv.TONGIAO,
                thamnien = (int)gv.THAMNIEN,
                masocd = gv.MASOCD,
                bac = gv.BAC,
                macm = gv.MACM
            };

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN ĐƯỢC LỌC
        public List<GiaoVienLocDTO> getDataGiaoVienLoc()
        {
            var giaoviens = from gv in qlgv.GIAOVIENs  where gv.TRANGTHAI == true select new GiaoVienLocDTO()
            {
                magv = gv.MAGV,
                hoten = gv.HOTEN,
                ngaysinh = (DateTime)gv.NGAYSINH,
                gioitinh = gv.GIOITINH,
            };

            List<GiaoVienLocDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ TÌM GIÁO VIÊN ĐƯỢC LỌC
        public List<GiaoVienLocDTO> findDataGiaoVienLoc(string pValue)
        {
            var giaoviens = from gv in qlgv.GIAOVIENs where gv.MAGV.Contains(pValue) || gv.HOTEN.Contains(pValue) && gv.TRANGTHAI == true select new GiaoVienLocDTO() 
            {
                magv = gv.MAGV,
                hoten = gv.HOTEN,
                ngaysinh = (DateTime)gv.NGAYSINH,
                gioitinh = gv.GIOITINH,
            };

            List<GiaoVienLocDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN THEO MÃ GIÁO VIÊN
        public List<GiaoVienDTO> getDataGiaoVienTheoMa(string pMaGV)
        {
            var giaoviens = from gv in qlgv.GIAOVIENs where gv.MAGV == pMaGV && gv.TRANGTHAI == true select new GiaoVienDTO()
            {
                magv = gv.MAGV,
                trangthai = (bool)gv.TRANGTHAI,
                hoten = gv.HOTEN,
                ngaysinh = (DateTime)gv.NGAYSINH,
                gioitinh = gv.GIOITINH,
                diachi = gv.DIACHI,
                sodienthoai = gv.SODIENTHOAI,
                cccd = gv.CCCD,
                email = gv.EMAIL,
                ngayvaotruong = (DateTime)gv.NGAYVAOTRUONG,
                ngayvaodang = (DateTime)gv.NGAYVAODANG,
                donvicongtac = gv.DONVICONGTAC,
                dantoc = gv.DANTOC,
                tongiao = gv.TONGIAO,
                thamnien = (int)gv.THAMNIEN,
                masocd = gv.MASOCD,
                bac = gv.BAC,
                macm = gv.MACM,
            };

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }
        //------------------ LẤY DỮ LIỆU GIÁO VIÊN THEO MÃ SỐ CHỨC DANH
        public List<GiaoVienDTO> getDataGiaoVienTheoMaChucDanh(string pMaSoCD)
        {
            var giaoviens = from gv in qlgv.GIAOVIENs
                            where gv.MASOCD == pMaSoCD && gv.TRANGTHAI == true
                            select new GiaoVienDTO()
                            {
                                magv = gv.MAGV,
                                trangthai = (bool)gv.TRANGTHAI,
                                hoten = gv.HOTEN,
                                ngaysinh = (DateTime)gv.NGAYSINH,
                                gioitinh = gv.GIOITINH,
                                diachi = gv.DIACHI,
                                sodienthoai = gv.SODIENTHOAI,
                                cccd = gv.CCCD,
                                email = gv.EMAIL,
                                ngayvaotruong = (DateTime)gv.NGAYVAOTRUONG,
                                ngayvaodang = (DateTime)gv.NGAYVAODANG,
                                donvicongtac = gv.DONVICONGTAC,
                                dantoc = gv.DANTOC,
                                tongiao = gv.TONGIAO,
                                thamnien = (int)gv.THAMNIEN,
                                masocd = gv.MASOCD,
                                bac = gv.BAC,
                                macm = gv.MACM,
                            };

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }
        //------------------ LẤY DỮ LIỆU GIÁO VIÊN THEO TÊN CHUYÊN MÔN
        public List<GiaoVienDTO> getDataGiaoVienTheoCM(int pMaMH, string pNamHoc)
        {
            //var q = from gv in qlgv.GIAOVIENs
            //                join cm in qlgv.CHUYENMONs on gv.MACM equals cm.MACM
            //                join ctcv in qlgv.CHITIETCHUCVUs on gv.MAGV equals ctcv.MAGV
            //                where cm.TENCM == pMaMH && gv.TRANGTHAI == true && ctcv.MACV == 3 || ctcv.MACV == 4 || ctcv.MACV == 5 || ctcv.MACV == 6
            //        select gv;
            var giaoviens = from gv in qlgv.GIAOVIENs
                            join cm in qlgv.CHUYENMONs on gv.MACM equals cm.MACM
                            join ctcv in qlgv.CHITIETCHUCVUs on gv.MAGV equals ctcv.MAGV
                            where cm.MACM == pMaMH && gv.TRANGTHAI == true 
                            && (ctcv.MACV == 3 || ctcv.MACV == 4 || ctcv.MACV == 5 || ctcv.MACV == 6)
                            && ctcv.NAMHOC == pNamHoc
                            select new GiaoVienDTO()
                            {
                                magv = gv.MAGV,
                                trangthai = (bool)gv.TRANGTHAI,
                                hoten = gv.HOTEN,
                                ngaysinh = (DateTime)gv.NGAYSINH,
                                gioitinh = gv.GIOITINH,
                                diachi = gv.DIACHI,
                                sodienthoai = gv.SODIENTHOAI,
                                cccd = gv.CCCD,
                                email = gv.EMAIL,
                                ngayvaotruong = (DateTime)gv.NGAYVAOTRUONG,
                                ngayvaodang = (DateTime)gv.NGAYVAODANG,
                                donvicongtac = gv.DONVICONGTAC,
                                dantoc = gv.DANTOC,
                                tongiao = gv.TONGIAO,
                                thamnien = (int)gv.THAMNIEN,
                                masocd = gv.MASOCD,
                                bac = gv.BAC,
                                macm = gv.MACM,
                            };

            List<GiaoVienDTO> lst_gv = giaoviens.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU GIÁO VIÊN KHÔNG TỒN TẠI TRONG CHỦ NHIỆM
        public List<GiaoVienDTO> getDataGiaoVienKhongTonTai(string pNamHoc)
        {
            var query = qlgv.GIAOVIENs.Where(gv => !qlgv.CHUNHIEMs.Any(cn => cn.MAGV == gv.MAGV && cn.NAMHOC == pNamHoc && cn.TRANGTHAI == true) && qlgv.CHITIETCHUCVUs.Any(ctcv => ctcv.MAGV == gv.MAGV && ctcv.MACV == 4) && gv.TRANGTHAI == true);

            var giaoviens = query.ToList().ConvertAll(gv => new GiaoVienDTO()
            {
                magv = gv.MAGV,
                trangthai = (bool)gv.TRANGTHAI,
                hoten = gv.HOTEN,
                ngaysinh = (DateTime)gv.NGAYSINH,
                gioitinh = gv.GIOITINH,
                diachi = gv.DIACHI,
                sodienthoai = gv.SODIENTHOAI,
                cccd = gv.CCCD,
                email = gv.EMAIL,
                ngayvaotruong = (DateTime)gv.NGAYVAOTRUONG,
                ngayvaodang = (DateTime)gv.NGAYVAODANG,
                donvicongtac = gv.DONVICONGTAC,
                dantoc = gv.DANTOC,
                tongiao = gv.TONGIAO,
                thamnien = (int)gv.THAMNIEN,
                masocd = gv.MASOCD,
                bac = gv.BAC,
                macm = gv.MACM
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
            gvs.TRANGTHAI = gv.trangthai;
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
            try
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
            catch
            {
                return false;
            }
        }

        //------------------ SỬA GIÁO VIÊN
        public void editGV(GiaoVienDTO gv)
        {
            GIAOVIEN gvs = qlgv.GIAOVIENs.Where(t => t.MAGV == gv.magv).FirstOrDefault();

            gvs.MAGV = gv.magv;
            gvs.TRANGTHAI = gv.trangthai;
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

        //------------------ KIỂM TRA CHỨC VỤ HIỆU TRƯỞNG
        public bool checkHT(string pMaGV)
        {
            var query = from gv in qlgv.GIAOVIENs join ctcv in qlgv.CHITIETCHUCVUs on gv.MAGV equals ctcv.MAGV where ctcv.MAGV == pMaGV && ctcv.MACV == 1 select gv;
            return query.Any();
        }

        //------------------ KIỂM TRA CHỨC VỤ HIỆU PHÓ
        public bool checkHP(string pMaGV)
        {
            var query = from gv in qlgv.GIAOVIENs join ctcv in qlgv.CHITIETCHUCVUs on gv.MAGV equals ctcv.MAGV where ctcv.MAGV == pMaGV && ctcv.MACV == 2 select gv;
            return query.Any();
        }

        //------------------ LẤY ĐỊNH MỨC TIẾT DẠY
        public decimal getDinhMucTietDay(string pMaGV, string pNamHoc)
        {
            var query = from gv in qlgv.GIAOVIENs
                        join ctcv in qlgv.CHITIETCHUCVUs on gv.MAGV equals ctcv.MAGV
                        join dmtd in qlgv.DINHMUCTIETDAYs on ctcv.MACV equals dmtd.MACV
                        where gv.MAGV == pMaGV && ctcv.NAMHOC == pNamHoc
                        select dmtd.SODINHMUCTIETDAY;
            return query.FirstOrDefault();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaGV)
        {
            var query = from gv in qlgv.GIAOVIENs where gv.MAGV == pMaGV select gv;
            return query.Any();
        }
    }
}
