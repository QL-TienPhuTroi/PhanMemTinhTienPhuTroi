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

        //------------------ LẤY DỮ LIỆU PHỤ TRỘI
        public List<PhuTroiDTO> getDataPhuTroi(string pNamHoc)
        {
            return pt_dal.getDataPhuTroi(pNamHoc);
        }

        //------------------ THÊM PHỤ TRỘI
        public void addPT(PhuTroiDTO pt, string pNamHoc)
        {
            pt_dal.addPT(pt, pNamHoc);
        }

        //------------------ XÓA PHỤ TRỘI
        public bool removePT(string pMaGV)
        {
            return pt_dal.removePT(pMaGV);
        }

        //------------------ SỬA PHỤ TRỘI
        public void editPT(PhuTroiDTO pt, string pNamHoc)
        {
            pt_dal.editPT(pt, pNamHoc);
        }

        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaGV)
        {
            return pt_dal.checkPK(pMaGV);
        }
    }
}
