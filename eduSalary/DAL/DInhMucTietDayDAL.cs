using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DInhMucTietDayDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public DInhMucTietDayDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU ĐỊNH MỨC TIẾT DẠY
        public List<DinhMucTietDayDTO> getDataDinhMucTietDay()
        {
            var dmtds = from dmtd in qlgv.DINHMUCTIETDAYs
                           select new DinhMucTietDayDTO()
                           {
                               macv = dmtd.MACV,
                               sodinhmuctietday = dmtd.SODINHMUCTIETDAY,
                           };

            List<DinhMucTietDayDTO> lst_dmtd = dmtds.ToList();

            return lst_dmtd;
        }

        //------------------ LẤY DỮ LIỆU ĐỊNH MỨC TIẾT DẠY THEO MÃ
        public List<DinhMucTietDayDTO> getDataDinhMucTietDayTheoMa(int pMaCV)
        {
            var dinhmuctietdays = from dmtd in qlgv.DINHMUCTIETDAYs
                           where dmtd.MACV == pMaCV
                                  select new DinhMucTietDayDTO()
                           {
                               macv = dmtd.MACV,
                               sodinhmuctietday = dmtd.SODINHMUCTIETDAY,
                              

                           };

            List<DinhMucTietDayDTO> lst_dmtd = dinhmuctietdays.ToList();

            return lst_dmtd;
        }
        //------------------ LẤY DỮ LIỆU ĐỊNH MỨC TIẾT DẠY THEO MÃ VÀ SỐ DMTD
        public List<DinhMucTietDayDTO> getDataDinhMucTietDayTheoMaVaSoDMTD(int pMaCV, decimal pSoDMTD)
        {
            var dinhmuctietdays = from dmtd in qlgv.DINHMUCTIETDAYs
                                  where dmtd.MACV == pMaCV && dmtd.SODINHMUCTIETDAY == pSoDMTD
                                  select new DinhMucTietDayDTO()
                                  {
                                      macv = dmtd.MACV,
                                      sodinhmuctietday = dmtd.SODINHMUCTIETDAY,


                                  };

            List<DinhMucTietDayDTO> lst_dmtd = dinhmuctietdays.ToList();

            return lst_dmtd;
        }

        //------------------ THÊM ĐỊNH MỨC TIẾT DẠY
        public void addDMTD(DinhMucTietDayDTO dmtd)
        {
            DINHMUCTIETDAY dmtds = new DINHMUCTIETDAY();

            dmtds.MACV = dmtd.macv;
            dmtds.SODINHMUCTIETDAY = dmtd.sodinhmuctietday;
           

            qlgv.DINHMUCTIETDAYs.InsertOnSubmit(dmtds);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA ĐỊNH MỨC TIẾT DẠY
        public bool removeDMTD(int pMaCV, decimal pSoDMTD)
        {
            DINHMUCTIETDAY dmtd = qlgv.DINHMUCTIETDAYs.Where(t => t.MACV == pMaCV && t.SODINHMUCTIETDAY == pSoDMTD).FirstOrDefault();
            if (dmtd != null)
            {
                qlgv.DINHMUCTIETDAYs.DeleteOnSubmit(dmtd);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA ĐỊNH MỨC TIẾT DẠY
        public void editDMTD(DinhMucTietDayDTO dmtd)
        {
            DINHMUCTIETDAY dmtds = qlgv.DINHMUCTIETDAYs.Where(t => t.MACV == dmtd.macv).FirstOrDefault();

            dmtds.MACV = dmtd.macv;
            dmtds.SODINHMUCTIETDAY = dmtd.sodinhmuctietday;

            qlgv.SubmitChanges();
        }
        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(int pMaDMTD)
        {
            var query = from dmtd in qlgv.DINHMUCTIETDAYs where dmtd.MACV == pMaDMTD select dmtd;
            return query.Any();
        }
        //------------------ TÌM ĐỊNH MỨC TIẾT DẠY
        public List<DinhMucTietDayDTO> findDataDinhMucTietDayLoc(string pValue)
        {
            var dinhmuctietdays = from dmtd in qlgv.DINHMUCTIETDAYs
                           where dmtd.MACV.ToString().Contains(pValue) || dmtd.SODINHMUCTIETDAY.ToString().Contains(pValue)
                                  select new DinhMucTietDayDTO()
                           {
                               macv = dmtd.MACV,
                               sodinhmuctietday = (decimal)dmtd.SODINHMUCTIETDAY,
                           };

            List<DinhMucTietDayDTO> lst_dmtd = dinhmuctietdays.ToList();

            return lst_dmtd;
        }
    }
}
