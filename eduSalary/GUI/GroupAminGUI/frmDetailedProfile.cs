using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI.GroupAminGUI
{
    public partial class frmDetailedProfile : Form
    {
        string pCode;
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        ChuyenMonBLL cm_bll = new ChuyenMonBLL();
        ChucDanhBLL cd_bll = new ChucDanhBLL();
        BacLuongBLL bl_bll = new BacLuongBLL();

        public frmDetailedProfile(string code)
        {
            InitializeComponent();
            this.Load += FrmDetailedProfile_Load;
            pCode = code;
        }

        private void FrmDetailedProfile_Load(object sender, EventArgs e)
        {
            loadDataProfile();
        }

        private void loadDataProfile()
        {
            //---------------- [ DANH SÁCH GIÁO VIÊN ] ----------------
            List<GiaoVienDTO> lstGV = new List<GiaoVienDTO>();
            lstGV = gv_bll.getDataGiaoVienTheoMa(pCode);

            //---------------- [ DANH SÁCH CHUYÊN MÔN ] ----------------
            List<ChuyenMonDTO> lstCM = new List<ChuyenMonDTO>();
            lstCM = cm_bll.getDataChuyenMonTheoMa(lstGV[0].macm);

            //---------------- [ DANH SÁCH CHỨC DANH ] ----------------
            List<ChucDanhDTO> lstCD = new List<ChucDanhDTO>();
            lstCD = cd_bll.getDataChucDanhTheoMa(lstGV[0].masocd);

            //---------------- [ DANH SÁCH BẬC LƯƠNG ] ----------------
            List<BacLuongDTO> lstBL = new List<BacLuongDTO>();
            lstBL = bl_bll.getDataBacLuongTheoMa(lstGV[0].masocd, lstGV[0].bac);


            lbMaGV.Text = lstGV[0].magv;
            if (lstGV[0].trangthai)
            {
                lbTinhTrang.Text = "Đang dạy";
            }
            else
            {
                lbTinhTrang.Text = "Nghỉ dạy";
            }
            lbHoTen.Text = lstGV[0].hoten;
            lbNgaySinh.Text = lstGV[0].ngaysinh.ToString("dd/MM/yyyy");
            lbGioiTinh.Text = lstGV[0].gioitinh;
            lbDiaChi.Text = lstGV[0].diachi;
            lbSoDienThoai.Text = lstGV[0].sodienthoai;
            lbCMND.Text = lstGV[0].cccd;
            lbEmail.Text = lstGV[0].email;
            lbNgayVaoTruong.Text = lstGV[0].ngayvaotruong.ToString("dd/MM/yyyy");
            lbNgayVaoDang.Text = lstGV[0].ngayvaodang.ToString("dd/MM/yyyy");
            lbDonViCongTac.Text = lstGV[0].donvicongtac;
            lbDanToc.Text = lstGV[0].dantoc;
            lbTonGiao.Text = lstGV[0].tongiao;
            lbThamNien.Text = lstGV[0].thamnien.ToString();
            lbMaCD.Text = lstGV[0].masocd;
            lbBac.Text = lstGV[0].bac.ToString();
            lbChuyenMon.Text = lstCM[0].tencm;
            lbHangCD.Text = lstCD[0].hangcd;
            lbHeSoLuong.Text = lstBL[0].hesoluong.ToString();
        }
    }
}
