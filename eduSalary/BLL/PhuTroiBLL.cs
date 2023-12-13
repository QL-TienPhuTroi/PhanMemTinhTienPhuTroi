using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class PhuTroiBLL
    {
        PhuTroiDAL pt_dal = new PhuTroiDAL();

        public PhuTroiBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU PHỤ TRỘI
        public List<PhuTroiDTO> getDataPhuTroi()
        {
            return pt_dal.getDataPhuTroi(); 
        }

        //------------------ THÊM PHỤ TRỘI
        public void addPT(PhuTroiDTO pt)
        {
            pt_dal.addPT(pt);
        }

        //------------------ XÓA PHỤ TRỘI
        public bool removePT(string pMaGV)
        {
            return pt_dal.removePT(pMaGV);
        }

        //------------------ SỬA PHỤ TRỘI
        public void editPT(PhuTroiDTO pt)
        {
            pt_dal.editPT(pt);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaGV)
        {
            return pt_dal.checkPK(pMaGV);
        }
    }
}
