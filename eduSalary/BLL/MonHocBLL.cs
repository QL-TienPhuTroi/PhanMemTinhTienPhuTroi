using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.IO;

namespace BLL
{
    public class MonHocBLL
    {
        MonHocDAL mh_dal = new MonHocDAL();

        public MonHocBLL()
        {

        }

        //------------------ LẤY DỮ LIỆU MÔN HỌC
        public List<MonHocDTO> getDataMonHoc()
        {
            return mh_dal.getDataMonHoc();
        }

        //------------------ LẤY DỮ LIỆU MÔN HỌC KHÔNG TỒN TẠI TRONG LỊCH DẠY
        public List<MonHocDTO> getDataMonHocKhongTonTai(string pMaLP, string pNamHoc, int pMaKhoi)
        {
            return mh_dal.getDataMonHocKhongTonTai(pMaLP, pNamHoc, pMaKhoi);
        }
        public bool checkPK(int pMaMH)
        {
            return mh_dal.checkPK(pMaMH);
        }
        //------------------ THÊM MÔN HỌC
        public void addMH(MonHocDTO mh)
        {
            mh_dal.addMH(mh);
        }

        //------------------ XÓA MÔN HỌC
        public bool removeMH(int pMaGV)
        {
            return mh_dal.removeMH(pMaGV);
        }

        //------------------ SỬA MÔN HỌC
        public void editMH(MonHocDTO mh)
        {
            mh_dal.editMH(mh);
        }
        //------------------ LẤY DỮ LIỆU MÔN HỌC THEO MÃ
        public List<MonHocDTO> getDataMonHocTheoMa(int pMaMH)
        {
            return mh_dal.getDataMonHocTheoMa(pMaMH);
        }
        //------------------ TÌM MÔN HỌC ĐƯỢC LỌC
        public List<MonHocDTO> findDataMonHoc(string pValue)
        {
            return mh_dal.findDataMonHoc(pValue);
        }

        //------------------ TÌM MÃ CHUYÊN MÔN THEO MÃ MÔN HỌC
        public int findMaChuyenMonTheoMaMonHoc(int pMaMH)
        {
            return mh_dal.findMaChuyenMonTheoMaMonHoc(pMaMH);
        }

        //------------------ LẤY SỐ TIẾT TỐI ĐA CỦA MÔN HỌC
        public int getSoTietToiDa(int pMaMH)
        {
            return mh_dal.getSoTietToiDa(pMaMH);
        }

        //------------------ LẤY MÃ MÔN HỌC THEO TÊN MÔN HỌC
        public int getMaMonHocTheoTenMH(string tenMH)
        {
            return mh_dal.getMaMonHocTheoTenMH(tenMH);
        }
    }
}
