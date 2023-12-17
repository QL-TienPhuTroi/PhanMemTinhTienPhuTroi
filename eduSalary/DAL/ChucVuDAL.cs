using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChucVuDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public ChucVuDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU CHỨC VỤ
        public List<ChucVuDTO> getDataChucVu()
        {
            var chucvus = from cv in qlgv.CHUCVUs select new ChucVuDTO()
            {
                macv = cv.MACV,
                tencv = cv.TENCV
            };

            List<ChucVuDTO> lst_cv = chucvus.ToList();

            return lst_cv;
        }
        //------------------ LẤY DỮ LIỆU CHỨC VỤ THEO MÃ
        public List<ChucVuDTO> getDataChucVuTheoMa(int pMaCV)
        {
            var chucvus = from cv in qlgv.CHUCVUs where cv.MACV == pMaCV
                          select new ChucVuDTO()
                          {
                              macv = cv.MACV,
                              tencv = cv.TENCV
                          };

            List<ChucVuDTO> lst_cv = chucvus.ToList();

            return lst_cv;
        }
        //------------------ THÊM BẰNG CẤP
        public void addCV(ChucVuDTO cv)
        {
            CHUCVU cvs = new CHUCVU();

            cvs.MACV = cv.macv;
            cvs.TENCV = cv.tencv;
           

            qlgv.CHUCVUs.InsertOnSubmit(cvs);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA BẰNG CẤP
        public bool removeCV(int pMaCV)
        {
            CHUCVU cv = qlgv.CHUCVUs.Where(t => t.MACV == pMaCV).FirstOrDefault();
            if (cv != null)
            {
                qlgv.CHUCVUs.DeleteOnSubmit(cv);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }
        //------------------ TÌM CHỨC VỤ
        public List<ChucVuDTO> findDataChucVuLoc(string pValue)
        {
            var chucvus = from cv in qlgv.CHUCVUs
                            where cv.MACV.ToString().Contains(pValue) || cv.TENCV.Contains(pValue)
                            select new ChucVuDTO()
                            {
                                macv = cv.MACV,
                                tencv = cv.TENCV,
                            };

            List<ChucVuDTO> lst_cv = chucvus.ToList();

            return lst_cv;
        }
        //------------------ SỬA BẰNG CẤP
        public void editCV(ChucVuDTO cv)
        {
            CHUCVU bcs = qlgv.CHUCVUs.Where(t => t.MACV == cv.macv).FirstOrDefault();

            bcs.MACV = cv.macv;
            bcs.TENCV = cv.tencv;
            

            qlgv.SubmitChanges();
        }
        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(int pMaCV)
        {
            var query = from cv in qlgv.CHUCVUs where cv.MACV == pMaCV select cv;
            return query.Any();
        }
    }
}
