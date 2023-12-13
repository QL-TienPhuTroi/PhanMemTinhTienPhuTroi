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
            var phutrois = from pt in qlgv.PHUTROIs select new PhuTroiDTO()
            {
                magv = pt.MAGV,
                tongtietday = (int)pt.TONGTIETDAY,
                sogiodaythem = (float)pt.SOGIODAYTHEM,
                luonggioday = (decimal)pt.LUONGGIODAY,
                tienphutroi = (decimal)pt.TIENPHUTROI
            };

            List<PhuTroiDTO> lst_gv = phutrois.ToList();

            return lst_gv;
        }

        //------------------ THÊM PHỤ TRỘI
        public void addPT(PhuTroiDTO pt)
        {
            PHUTROI pts = new PHUTROI();

            pts.MAGV = pt.magv;
            pts.TONGTIETDAY = pt.tongtietday;
            pts.SOGIODAYTHEM = pt.sogiodaythem;
            pts.LUONGGIODAY = pt.luonggioday;
            pts.TIENPHUTROI = pt.tienphutroi;

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
        public void editPT(PhuTroiDTO pt)
        {
            PHUTROI pts = qlgv.PHUTROIs.Where(t => t.MAGV == pt.magv).FirstOrDefault();

            pts.MAGV = pt.magv;
            pts.TONGTIETDAY = pt.tongtietday;
            pts.SOGIODAYTHEM = pt.sogiodaythem;
            pts.LUONGGIODAY = pt.luonggioday;
            pts.TIENPHUTROI = pt.tienphutroi;

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
