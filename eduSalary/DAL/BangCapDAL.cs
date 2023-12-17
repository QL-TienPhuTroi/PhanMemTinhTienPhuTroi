using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class BangCapDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public BangCapDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU BẰNG CẤP
        public List<BangCapDTO> getDataBangCap()
        {
            var bangcaps = from bc in qlgv.BANGCAPs
                           select new BangCapDTO()
                           {
                               mabc = bc.MABC,
                               tenbc = bc.TENBC,
                               noidaotao = bc.NOIDAOTAO,
                               chuyennganh = bc.CHUYENNGANH,
                               hocvi = bc.HOCVI,
                               xeploai = bc.XEPLOAI,
                               ngaycap = (DateTime)bc.NGAYCAP,
                            };

            List<BangCapDTO> lst_bc = bangcaps.ToList();

            return lst_bc;
        }

        //------------------ LẤY DỮ LIỆU BẰNG CẤP THEO MÃ
        public List<BangCapDTO> getDataBangCapTheoMa(string pMaBC)
        {
            var bangcaps = from bc in qlgv.BANGCAPs
                            where bc.MABC == pMaBC
                            select new BangCapDTO()
                            {
                                mabc = bc.MABC,
                                tenbc = bc.TENBC,
                                noidaotao = bc.NOIDAOTAO,
                                chuyennganh = bc.CHUYENNGANH,
                                hocvi = bc.HOCVI,
                                xeploai = bc.XEPLOAI,
                                ngaycap = (DateTime)bc.NGAYCAP,
                                
                            };

            List<BangCapDTO> lst_bc = bangcaps.ToList();

            return lst_bc;
        }
        //------------------ THÊM BẰNG CẤP
        public void addBC(BangCapDTO bc)
        {
            BANGCAP bcs = new BANGCAP();

            bcs.MABC = bc.mabc;
            bcs.TENBC = bc.tenbc;
            bcs.NOIDAOTAO = bc.noidaotao;
            bcs.CHUYENNGANH = bc.chuyennganh;
            bcs.HOCVI = bc.hocvi;
            bcs.XEPLOAI = bc.xeploai;
            bcs.NGAYCAP = bc.ngaycap;

            qlgv.BANGCAPs.InsertOnSubmit(bcs);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA BẰNG CẤP
        public bool removeBC(string pMaBC)
        {
            BANGCAP bc = qlgv.BANGCAPs.Where(t => t.MABC == pMaBC).FirstOrDefault();
            if (bc != null)
            {
                qlgv.BANGCAPs.DeleteOnSubmit(bc);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA BẰNG CẤP
        public void editBC(BangCapDTO bc)
        {
            BANGCAP bcs = qlgv.BANGCAPs.Where(t => t.MABC == bc.mabc).FirstOrDefault();

            bcs.MABC = bc.mabc;
            bcs.TENBC = bc.tenbc;
            bcs.NOIDAOTAO = bc.noidaotao;
            bcs.CHUYENNGANH = bc.chuyennganh;
            bcs.HOCVI = bc.hocvi;
            bcs.XEPLOAI = bc.xeploai;
            bcs.NGAYCAP = bc.ngaycap;

            qlgv.SubmitChanges();
        }
        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaBC)
        {
            var query = from bc in qlgv.BANGCAPs where bc.MABC == pMaBC select bc;
            return query.Any();
        }
        //------------------ TÌM BẰNG CẤP
        public List<BangCapDTO> findDataBangCapLoc(string pValue)
        {
            var bangcaps = from bc in qlgv.BANGCAPs
                          where bc.MABC.ToString().Contains(pValue) || bc.TENBC.Contains(pValue) || bc.NOIDAOTAO.Contains(pValue) || bc.CHUYENNGANH.Contains(pValue) || bc.HOCVI.Contains(pValue) || bc.XEPLOAI.Contains(pValue) || bc.NGAYCAP.ToString().Contains(pValue)
                           select new BangCapDTO()
                          {
                              mabc = bc.MABC,
                              tenbc = bc.TENBC,
                               noidaotao = bc.NOIDAOTAO,
                               chuyennganh = bc.CHUYENNGANH,
                               hocvi = bc.HOCVI,
                               xeploai = bc.XEPLOAI,
                               ngaycap = (DateTime)bc.NGAYCAP,
                           };

            List<BangCapDTO> lst_bc = bangcaps.ToList();

            return lst_bc;
        }
    }
}
