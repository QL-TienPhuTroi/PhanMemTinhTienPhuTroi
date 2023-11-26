using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DTO;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class ChuNhiemDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ChuNhiemDAL()
        {

        }

        //------------------ KIỂM TRA LỚP ĐÃ CÓ GIÁO VIÊN CHỦ NHIỆM CHƯA
        public bool isHomerooms(string pMaLP, string pNamHoc)
        {
            var query = from cn in qlgv.CHUNHIEMs where cn.MALP == pMaLP && cn.NAMHOC == pNamHoc && cn.TRANGTHAI == true select cn;
            return query.Any();
        }

        //------------------ THÊM CHỦ NHIỆM
        public void addCN(ChuNhiemDTO cn)
        {
            CHUNHIEM cns = new CHUNHIEM();

            cns.MALP = cn.malp;
            cns.MAGV = cn.magv;
            cns.NAMHOC = cn.namhoc;
            cns.TRANGTHAI = cn.trangthai;

            qlgv.CHUNHIEMs.InsertOnSubmit(cns);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA CHỦ NHIỆM
        public bool removeCN(string pMaGV, string pMaLP, string pNamHoc)
        {
            CHUNHIEM cn = qlgv.CHUNHIEMs.Where(t => t.MAGV == pMaGV && t.MALP == pMaLP && t.NAMHOC == pNamHoc).FirstOrDefault();
            if (cn != null)
            {
                qlgv.CHUNHIEMs.DeleteOnSubmit(cn);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA CHỦ NHIỆM
        public void editCN(ChuNhiemDTO cn)
        {
            CHUNHIEM cns = qlgv.CHUNHIEMs.Where(t => t.MALP == cn.malp && t.NAMHOC == cn.namhoc).FirstOrDefault();

            cns.MALP = cn.malp;
            cns.MAGV = cn.magv;
            cns.NAMHOC = cn.namhoc;
            cns.TRANGTHAI = cn.trangthai;

            qlgv.SubmitChanges();
        }

        //------------------ TÌM GIÁO VIÊN CHỮ NHIỆM HIỆN TẠI
        public ChuNhiemDTO findTeacherNow(string pMaLP, string pNamHoc)
        {
            var query = qlgv.CHUNHIEMs.Where(t => t.MALP == pMaLP && t.NAMHOC == pNamHoc && t.TRANGTHAI == true);

            var chunhiems = query.ToList().ConvertAll(cn => new ChuNhiemDTO()
            {
                magv = cn.MAGV,
                malp = cn.MALP,
                namhoc = cn.NAMHOC,
                trangthai = (bool)cn.TRANGTHAI
        });

            List<ChuNhiemDTO> lst_cn = chunhiems;

            return lst_cn.FirstOrDefault();
        }
    }
}
