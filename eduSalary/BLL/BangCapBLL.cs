using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BangCapBLL
    {
        BangCapDAL bc_dal = new BangCapDAL();
        //------------------ LẤY DỮ LIỆU BẰNG CẤP
        public List<BangCapDTO> getDataBangCap()
        {
            return bc_dal.getDataBangCap();
        }
        //------------------ LẤY DỮ LIỆU BẰNG CẤP THEO MÃ
        public List<BangCapDTO> getDataBangCapTheoMa(string pMaBC)
        {
            return bc_dal.getDataBangCapTheoMa(pMaBC);
        }
        //------------------ THÊM BẰNG CẤP
        public void addBC(BangCapDTO bc)
        {
            bc_dal.addBC(bc);
        }
        //------------------ TÌM BẰNG CẤP ĐƯỢC LỌC
        public List<BangCapDTO> findDataBangCapLoc(string pValue)
        {
            return bc_dal.findDataBangCapLoc(pValue);
        }
        //------------------ XÓA BẰNG CẤP
        public bool removeBC(string pMaBC)
        {
            return bc_dal.removeBC(pMaBC);
        }

        //------------------ SỬA BẰNG CẤP
        public void editBC(BangCapDTO bc)
        {
            bc_dal.editBC(bc);
        }
        //------------------ KIẾM TRA KHÓA CHÍNH
        public bool checkPK(string pMaBC)
        {
            return bc_dal.checkPK(pMaBC);
        }
    }
}
