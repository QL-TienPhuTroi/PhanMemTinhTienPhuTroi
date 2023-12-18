using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietChucVuBLL
    {
        ChiTietChucVuDAL ctcv_dal = new ChiTietChucVuDAL();

        public ChiTietChucVuBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHI TIẾT CHỨC VỤ
        public List<ChiTietChucVuDTO> getDataChiTietChucVu()
        {
            return ctcv_dal.getDataChiTietChucVu();
        }

        //------------------ THÊM CHI TIẾT CHỨC VỤ
        public void addCTCV(ChiTietChucVuDTO ctcv)
        {
            ctcv_dal.addCTCV(ctcv);
        }

        //------------------ XÓA CHI TIẾT CHỨC VỤ
        public bool removeCTCV(string pMaGV)
        {
           return ctcv_dal.removeCTCV(pMaGV);
        }

        //------------------ SỬA CHI TIẾT CHỨC VỤ
        public void editCTCV(ChiTietChucVuDTO ctcv)
        {
            ctcv_dal.editCTCV(ctcv);
        }
    }
}
