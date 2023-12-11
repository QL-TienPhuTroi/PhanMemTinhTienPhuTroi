using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MonHocDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public MonHocDAL() 
        { 
        
        }

        //------------------ LẤY DỮ LIỆU MÔN HỌC
        public List<MonHocDTO> getDataMonHoc()
        {
            var monhocs = from mh in qlgv.MONHOCs select new MonHocDTO()
            {
                mamh = mh.MAMH,
                tenmh = mh.TENMH
            };

            List<MonHocDTO> lst_mh = monhocs.ToList();

            return lst_mh;
        }

        //------------------ LẤY DỮ LIỆU MÔN HỌC KHÔNG TỒN TẠI TRONG LỊCH DẠY
        public List<MonHocDTO> getDataMonHocKhongTonTai(string pMaLP, string pNamHoc)
        {
            var query = qlgv.MONHOCs.Where(mh => !qlgv.LICHDAYs.Any(ld => ld.MAMH == mh.MAMH && ld.MALP == pMaLP && ld.NAMHOC == pNamHoc));

            var monhocs = query.ToList().ConvertAll(mh => new MonHocDTO()
            {
                mamh = mh.MAMH,
                tenmh = mh.TENMH
            });

            List<MonHocDTO> lst_mh = monhocs.ToList();

            return lst_mh;
        }
    }
}
