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
        public bool checkPK(int pMaMH)
        {
            var query = from mh in qlgv.MONHOCs where mh.MAMH == pMaMH select mh;
            return query.Any();
        }

        //------------------ THÊM GIÁO VIÊN
        public void addMH(MonHocDTO mh)
        {
            MONHOC mhs = new MONHOC();
            mhs.MAMH = mh.mamh;
            mhs.TENMH = mh.tenmh;
            qlgv.MONHOCs.InsertOnSubmit(mhs);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA GIÁO VIÊN
        public bool removeMH(int pMaMH)
        {
            MONHOC mh = qlgv.MONHOCs.Where(t => t.MAMH == pMaMH).FirstOrDefault();
            if (mh != null)
            {
                qlgv.MONHOCs.DeleteOnSubmit(mh);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA GIÁO VIÊN
        public void editMH(MonHocDTO mh)
        {
            MONHOC mhs = qlgv.MONHOCs.Where(t => t.MAMH == mh.mamh).FirstOrDefault();

            mhs.MAMH = mh.mamh;
            mhs.TENMH = mh.tenmh;

            qlgv.SubmitChanges();
        }
        //------------------ LẤY DỮ LIỆU MÔN HỌC THEO MÃ MÔN HỌC
        public List<MonHocDTO> getDataMonHocTheoMa(int pMaMH)
        {
            var monhocs = from mh in qlgv.MONHOCs
                            where mh.MAMH == pMaMH 
                            select new MonHocDTO()
                            {
                                mamh = mh.MAMH,
                                tenmh = mh.TENMH, 
                            };

            List<MonHocDTO> lst_mh = monhocs.ToList();

            return lst_mh;
        }
        //------------------ TÌM MÔN HỌC ĐƯỢC LỌC
        public List<MonHocDTO> findDataMonHoc(string pValue)
        {
            var monhocs = from mh in qlgv.MONHOCs
                            where mh.MAMH.ToString().Contains(pValue) || mh.TENMH.Contains(pValue)
                            select new MonHocDTO()
                            {
                                mamh = mh.MAMH,
                                tenmh = mh.TENMH,            
                            };

            List<MonHocDTO> lst_mh = monhocs.ToList();

            return lst_mh;
        }
    }
}
