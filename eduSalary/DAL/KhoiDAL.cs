using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhoiDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public KhoiDAL()
        {

        }
        //------------------ LẤY DỮ LIỆU KHỐI
        public List<KhoiDTO> getDataKhoi()
        {
            var khois = from kh in qlgv.KHOIs
                            select new KhoiDTO()
                            {
                                makhoi = kh.MAKHOI,
                                tenkhoi = kh.TENKHOI,
                            };
            List<KhoiDTO> lst_kh = khois.ToList();

            return lst_kh;
        }
        //------------------ LẤY DỮ LIỆU KHỐI THEO MÃ
        public string getDataTenKhoiTheoMa(int pMaKhoi)
        {
            var khois = from kh in qlgv.KHOIs 
                        where kh.MAKHOI == pMaKhoi
                        select kh.TENKHOI;

            return khois.FirstOrDefault();
        }

    }
}
