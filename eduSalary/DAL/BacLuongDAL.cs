using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BacLuongDAL
    {
        QLGVDataContext qlgv = new QLGVDataContext();

        public BacLuongDAL()
        {

        }

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG
        public List<BacLuongDTO> getDataBacLuong()
        {
            var bacluongs = from bl in qlgv.BACLUONGs select new BacLuongDTO()
            {
                masocd = bl.MASOCD,
                bac = bl.BAC,
                hesoluong = (decimal)bl.HESOLUONG,
                mucluongcoso = (decimal)bl.MUCLUONGCOSO
            };

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }
        //------------------ TÌM BẬC LƯƠNG
        public List<BacLuongDTO> findDataBacLuongLoc(string pValue)
        {
            var bacluongs = from bl in qlgv.BACLUONGs
                            where bl.MASOCD.Contains(pValue) || bl.BAC.ToString().Contains(pValue) || bl.HESOLUONG.ToString().Contains(pValue) || bl.MUCLUONGCOSO.ToString().Contains(pValue)
                            select new BacLuongDTO()
                            {
                                masocd = bl.MASOCD,
                                bac = bl.BAC,
                                hesoluong = (decimal)bl.HESOLUONG,
                                mucluongcoso = (decimal)bl.MUCLUONGCOSO,
                            };

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }
        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMa(string pMaSoCD, int pBac)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD && bl.BAC == pBac select new BacLuongDTO()
            {
                masocd = bl.MASOCD,
                bac = bl.BAC,
                hesoluong = (decimal)bl.HESOLUONG,
                mucluongcoso = (decimal)bl.MUCLUONGCOSO
            };

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }

        //------------------ LẤY DỮ LIỆU BẬC LƯƠNG THEO MÃ SỐ CHỨC DANH VÀ BẬC
        public List<BacLuongDTO> getDataBacLuongTheoMaCD(string pMaSoCD)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD select new BacLuongDTO()
            {
                masocd = bl.MASOCD,
                bac = bl.BAC,
                hesoluong = (decimal)bl.HESOLUONG,
                mucluongcoso = (decimal)bl.MUCLUONGCOSO
            };

            List<BacLuongDTO> lst_bl = bacluongs.ToList();

            return lst_bl;
        }

        //------------------ LẤY MỨC LƯƠNG CƠ SỞ
        public decimal getMucLuongCoSo(string pMaSoCD, int pBac)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD && bl.BAC == pBac select bl.MUCLUONGCOSO;

            return (decimal)bacluongs.FirstOrDefault();
        }

        //------------------ LẤY HỆ SỐ LƯƠNG
        public decimal getHeSoLuong(string pMaSoCD, int pBac)
        {
            var bacluongs = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD && bl.BAC == pBac select bl.HESOLUONG;

            return (decimal)bacluongs.FirstOrDefault();
        }

        //------------------ THÊM BẬC LƯƠNG
        public void addBL(BacLuongDTO bl)
        {
            BACLUONG bls = new BACLUONG();

            bls.MASOCD = bl.masocd;
            bls.BAC = bl.bac;
            bls.HESOLUONG = bl.hesoluong;
            bls.MUCLUONGCOSO = bl.mucluongcoso;
           
            qlgv.BACLUONGs.InsertOnSubmit(bls);
            qlgv.SubmitChanges();
        }

        //------------------ XÓA BẬC LƯƠNG
        public bool removeBL(string pMaSoCD, int pBac)
        {
            BACLUONG bl = qlgv.BACLUONGs.Where(t => t.MASOCD == pMaSoCD && t.BAC == pBac).FirstOrDefault();
            if (bl != null)
            {
                qlgv.BACLUONGs.DeleteOnSubmit(bl);
                qlgv.SubmitChanges();
                return true;
            }
            return false;
        }

        //------------------ SỬA BẬC LƯƠNG
        public void editBL(BacLuongDTO bl)
        {
            BACLUONG bls = qlgv.BACLUONGs.Where(t => t.MASOCD == bl.masocd).FirstOrDefault();

            bls.MASOCD = bl.masocd;
            bls.BAC = bl.bac;
            bls.HESOLUONG = bl.hesoluong;
            bls.MUCLUONGCOSO = bl.mucluongcoso;
            
            qlgv.SubmitChanges();
        }
        //------------------ KIỂM TRA KHÓA CHÍNH
        public bool checkPK(string pMaSoCD)
        {
            var query = from bl in qlgv.BACLUONGs where bl.MASOCD == pMaSoCD select bl;
            return query.Any();
        }
    }
}
