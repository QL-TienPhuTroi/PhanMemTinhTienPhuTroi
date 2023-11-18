using BLL;
using DTO;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Properties;

namespace GUI.GroupTeacherGUI
{
    public partial class frmProfile : Form
    {
        string pMaGV;
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        ChuyenMonBLL cm_bll = new ChuyenMonBLL();
        ChucDanhBLL cd_bll = new ChucDanhBLL();
        BacLuongBLL bl_bll = new BacLuongBLL();

        public frmProfile(string pCode)
        {
            InitializeComponent();
            pMaGV = pCode;
            this.Load += FrmProfile_Load;
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            loadDataProfile();
        }

        private void loadDataProfile()
        {
            //---------------- [ DANH SÁCH GIÁO VIÊN ] ----------------
            List<GiaoVienDTO> lstGV = new List<GiaoVienDTO>();
            lstGV = gv_bll.getDataGiaoVienTheoMa(pMaGV);

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

            //string pPath = "Resources\\" + getCharName(lbHoTen.Text).ToString() + ".png";
            //setPictureAvatar(pPath);

        }

        private void setPictureAvatar(string pPath)
        {
            //ResourceManager resourceManager = new ResourceManager("Properties.Resources", Assembly.GetExecutingAssembly());

            //Image avatar = (Image)resourceManager.GetObject(pPath);
            //picAvatar.Image = avatar;

            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pPath);
            Image newImage = Image.FromFile(fullPath);
            picAvatar.Image = newImage;
        }

        public char getCharName(string pHoTen)
        {
            string[] names = pHoTen.Split(' ');
            char[] c = names[names.Length - 1].ToCharArray();
            return c[0];
        }
    }
}
