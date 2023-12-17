using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChucVuBLL
    {
        ChucVuDAL cv_dal = new ChucVuDAL();

        //------------------ LẤY DỮ LIỆU CHỨC VỤ
        public List<ChucVuDTO> getDataChucVu()
        {
            return cv_dal.getDataChucVu();
        }
        //------------------ TÌM CHỨC VỤ ĐƯỢC LỌC
        public List<ChucVuDTO> findDataChucVuLoc(string pValue)
        {
            return cv_dal.findDataChucVuLoc(pValue);
        }
        //------------------ LẤY DỮ LIỆU CHỨC VỤ THEO MÃ
        public List<ChucVuDTO> getDataChucVuTheoMa(int pMaVC)
        {
            return cv_dal.getDataChucVuTheoMa(pMaVC);
        }
        //------------------ THÊM BẰNG CẤP
        public void addCV(ChucVuDTO cv)
        {
            cv_dal.addCV(cv);
        }

        //------------------ XÓA BẰNG CẤP
        public bool removeCV(int pMaCV)
        {
            return cv_dal.removeCV(pMaCV);
        }

        //------------------ SỬA BẰNG CẤP
        public void editCV(ChucVuDTO cv)
        {
            cv_dal.editCV(cv);
        }
        //------------------ KIẾM TRA KHÓA CHÍNH
        public bool checkPK(int pMaCV)
        {
            return cv_dal.checkPK(pMaCV);
        }
    }
}
