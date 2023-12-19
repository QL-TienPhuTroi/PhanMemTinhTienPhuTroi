using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhuTroiDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public PhuTroiDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU PHỤ TRỘI
        public List<PhuTroiDTO> getDataPhuTroi()
        {
            var phutrois = from pt in qlgv.PHUTROIs
                           select new PhuTroiDTO()
                            {
                                magv = pt.MAGV,
                                tongtietday = (int)pt.TONGTIETDAY,
                                tongtietdaday = (int)pt.TONGTIETDADAY,
                                tongtietquydinh = (int)pt.TONGTIETQUYDINH,
                                sogiodaythem = (float)pt.SOGIODAYTHEM,
                                luonggioday = (decimal)pt.LUONGGIODAY,
                                tienphutroi = (decimal)pt.TIENPHUTROI
                            };

            List<PhuTroiDTO> lst_gv = phutrois.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU PHỤ TRỘI
        public List<PhuTroiDTO> getDataPhuTroi(string pMaGV, string pNamHoc)
        {
            var phutrois = from pt in qlgv.PHUTROIs
                           where pt.MAGV.Contains(pMaGV) && pt.NAMHOC == pNamHoc
                           select new PhuTroiDTO()
                           {
                               magv = pt.MAGV,
                               tongtietday = (int)pt.TONGTIETDAY,
                               tongtietdaday = (int)pt.TONGTIETDADAY,
                               tongtietquydinh = (int)pt.TONGTIETQUYDINH,
                               sogiodaythem = (float)pt.SOGIODAYTHEM,
                               luonggioday = (decimal)pt.LUONGGIODAY,
                               tienphutroi = (decimal)pt.TIENPHUTROI
                           };

            List<PhuTroiDTO> lst_gv = phutrois.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU PHỤ TRỘI
        public List<PhuTroiDTO> getDataPhuTroi(string pNamHoc)
        {
            var phutrois = from pt in qlgv.PHUTROIs
                           where pt.NAMHOC == pNamHoc
                           select new PhuTroiDTO()
                           {
                               magv = pt.MAGV,
                               tongtietday = (int)pt.TONGTIETDAY,
                               tongtietdaday = (int)pt.TONGTIETDADAY,
                               tongtietquydinh = (int)pt.TONGTIETQUYDINH,
                               sogiodaythem = (float)pt.SOGIODAYTHEM,
                               luonggioday = (decimal)pt.LUONGGIODAY,
                               tienphutroi = (decimal)pt.TIENPHUTROI
                           };

            List<PhuTroiDTO> lst_gv = phutrois.ToList();

            return lst_gv;
        }

        //------------------ LẤY DỮ LIỆU PHỤ TRỘI THEO MAGV
        public List<PhuTroiDTO> getDataPhuTroiTheoMaGV(string pMaGV, string pNamHoc)
        {
            var phutrois = from pt in qlgv.PHUTROIs
                           where pt.MAGV == pMaGV && pt.NAMHOC == pNamHoc
                           select new PhuTroiDTO()
                           {
                               magv = pt.MAGV,
                               tongtietday = (int)pt.TONGTIETDAY,
                               tongtietdaday = (int)pt.TONGTIETDADAY,
                               tongtietquydinh = (int)pt.TONGTIETQUYDINH,
                               sogiodaythem = (float)pt.SOGIODAYTHEM,
                               luonggioday = (decimal)pt.LUONGGIODAY,
                               tienphutroi = (decimal)pt.TIENPHUTROI
                           };

            List<PhuTroiDTO> lst_gv = phutrois.ToList();

            return lst_gv;
        }

        //------------------ THÊM PHỤ TRỘI
        public void addPT(PhuTroiDTO pt, string pNamHoc)
        {
            PHUTROI pts = new PHUTROI();

            pts.MAGV = pt.magv;
            pts.TONGTIETDAY = pt.tongtietday;
            pts.TONGTIETDADAY = pt.tongtietdaday;
            pts.TONGTIETQUYDINH = pt.tongtietquydinh;
            pts.SOGIODAYTHEM = pt.sogiodaythem;
            pts.LUONGGIODAY = pt.luonggioday;
            pts.TIENPHUTROI = pt.tienphutroi;
            pts.NAMHOC = pNamHoc;

            qlgv.PHUTROIs.InsertOnSubmit(pts);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA PHỤ TRỘI
        public bool removePT(string pMaGV)
        {
            PHUTROI pt = qlgv.PHUTROIs.Where(t => t.MAGV == pMaGV).FirstOrDefault();
            if (pt != null)
            {
                qlgv.PHUTROIs.DeleteOnSubmit(pt);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA PHỤ TRỘI
        public void editPT(PhuTroiDTO pt, string pNamHoc)
        {
            PHUTROI pts = qlgv.PHUTROIs.Where(t => t.MAGV == pt.magv).FirstOrDefault();

            pts.MAGV = pt.magv;
            pts.TONGTIETDAY = pt.tongtietday;
            pts.TONGTIETDADAY = pt.tongtietdaday;
            pts.TONGTIETQUYDINH = pt.tongtietquydinh;
            pts.SOGIODAYTHEM = pt.sogiodaythem;
            pts.LUONGGIODAY = pt.luonggioday;
            pts.TIENPHUTROI = pt.tienphutroi;
            pts.NAMHOC = pNamHoc;

            qlgv.SubmitChanges();
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaGV)
        {
            var query = from pt in qlgv.PHUTROIs where pt.MAGV == pMaGV select pt;
            return query.Any();
        }
    }
}
