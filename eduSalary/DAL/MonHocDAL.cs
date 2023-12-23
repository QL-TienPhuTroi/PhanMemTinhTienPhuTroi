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
            var monhocs = from mh in qlgv.MONHOCs
                          select new MonHocDTO()
                          {
                              mamh = mh.MAMH,
                              tenmh = mh.TENMH,
                              tiettoida = (int)mh.TIETTOIDA,
                              macm = (int)mh.MACM,
                              makhoi = (int)mh.MAKHOI
                          };

            List<MonHocDTO> lst_mh = monhocs.ToList();

            return lst_mh;
        }
        //------------------ LẤY MÃ KHỐI CỦA MÔN HỌC
        public int getKhoi(int pMaMH)
        {
            var monhocs = from mh in qlgv.MONHOCs
                          where mh.MAMH == pMaMH
                          select mh.MAKHOI;

            return (int)monhocs.FirstOrDefault();
        }
        //------------------ LẤY DỮ LIỆU MÔN HỌC KHÔNG TỒN TẠI TRONG LỊCH DẠY
        public List<MonHocDTO> getDataMonHocKhongTonTai(string pMaLP, string pNamHoc, int pMaKhoi)
        {
            var query = qlgv.MONHOCs.Where(mh => !qlgv.LICHDAYs.Any(ld => ld.MAMH == mh.MAMH && ld.MALP == pMaLP && ld.NAMHOC == pNamHoc) && mh.MAKHOI == pMaKhoi);

            var monhocs = query.ToList().ConvertAll(mh => new MonHocDTO()
            {
                mamh = mh.MAMH,
                tenmh = mh.TENMH,
                tiettoida = (int)mh.TIETTOIDA,
                macm = (int)mh.MACM,
                makhoi = (int)mh.MAKHOI
            });

            List<MonHocDTO> lst_mh = monhocs.ToList();

            return lst_mh;
        }
        public bool checkPK(int pMaMH)
        {
            var query = from mh in qlgv.MONHOCs where mh.MAMH == pMaMH select mh;
            return query.Any();
        }

        //------------------ THÊM MÔN HỌC
        public void addMH(MonHocDTO mh)
        {
            MONHOC mhs = new MONHOC();
            mhs.MAMH = mh.mamh;
            mhs.TENMH = mh.tenmh;
            mhs.TIETTOIDA = mh.tiettoida;
            mhs.MACM = mh.macm;
            mhs.MAKHOI = mh.makhoi;
            qlgv.MONHOCs.InsertOnSubmit(mhs);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA MÔN HỌC
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
        //------------------ SỬA MÔN HỌC
        public void editMH(MonHocDTO mh)
        {
            MONHOC mhs = qlgv.MONHOCs.Where(t => t.MAMH == mh.mamh).FirstOrDefault();

            mhs.MAMH = mh.mamh;
            mhs.TENMH = mh.tenmh;
            mhs.TIETTOIDA = mh.tiettoida;
            mhs.MACM = mh.macm;
            mhs.MAKHOI = mh.makhoi;

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
                              tiettoida = (int)mh.TIETTOIDA,
                              macm = (int)mh.MACM,
                              makhoi = (int)mh.MAKHOI,
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
                              tiettoida = (int)mh.TIETTOIDA,
                              macm = (int)mh.MACM,
                              makhoi = (int)mh.MAKHOI,
                          };

            List<MonHocDTO> lst_mh = monhocs.ToList();

            return lst_mh;
        }

        //------------------ TÌM MÃ CHUYÊN MÔN THEO MÃ MÔN HỌC
        public int findMaChuyenMonTheoMaMonHoc(int pMaMH)
        {
            var monhocs = from mh in qlgv.MONHOCs
                          where mh.MAMH == pMaMH
                          select mh.MACM;

            return (int)monhocs.FirstOrDefault();
        }

        //------------------ LẤY SỐ TIẾT TỐI ĐA CỦA MÔN HỌC
        public int getSoTietToiDa(int pMaMH)
        {
            var monhocs = from mh in qlgv.MONHOCs
                          where mh.MAMH == pMaMH
                          select mh.TIETTOIDA;

            return (int)monhocs.FirstOrDefault();
        }

        //------------------ LẤY MÃ MÔN HỌC THEO TÊN MÔN HỌC
        public int getMaMonHocTheoTenMH(string tenMH)
        {
            var monhocs = from mh in qlgv.MONHOCs
                          where mh.TENMH == tenMH
                          select mh.MAMH;

            return (int)monhocs.FirstOrDefault();
        }
        //------------------ LẤY MÃ CHUYÊN MÔN CỦA MÔN HỌC
        public int getChuyenMon(int pMaCM)
        {
            var chuyenmons = from cm in qlgv.CHUYENMONs
                          where cm.MACM == pMaCM
                             select cm.MACM;

            return (int)chuyenmons.FirstOrDefault();
        }
    }
}
