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
    public partial class frmAddTeacher : Form
    {
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        GiaoVienDTO gv_dto = new GiaoVienDTO();

        TaiKhoanBLL tk_bll = new TaiKhoanBLL();
        TaiKhoanDTO tk_dto = new TaiKhoanDTO();

        ChiTietChucVuBLL ctcv_bll = new ChiTietChucVuBLL();
        ChiTietChucVuDTO ctcv_dto = new ChiTietChucVuDTO();


        BacLuongBLL bl_bll = new BacLuongBLL();
        ChucDanhBLL cd_bll = new ChucDanhBLL();
        ChuyenMonBLL cm_bll = new ChuyenMonBLL();

        public frmAddTeacher()
        {
            InitializeComponent();
            this.Load += FrmAddTeacher_Load;
            btnFinish.Click += BtnFinish_Click;
            cboMSCD.SelectedIndexChanged += CboMSCD_SelectedIndexChanged;
        }

        private void CboMSCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataBacLuong();
        }

        private void FrmAddTeacher_Load(object sender, EventArgs e)
        {
            loadDataChucDanh();
            loadDataChuyenMon();
            loadDataBacLuong();
            loadDataTrangThai();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            string pMaGV = createCode();

            try
            {
                //------- THÊM GIÁO VIÊN
                gv_dto.magv = pMaGV;
                if(cboTrangThai.SelectedItem.ToString() == "Đang dạy")
                {
                    gv_dto.trangthai = true;
                }
                else
                {
                    gv_dto.trangthai = false;
                }
                gv_dto.hoten = txtHoTen.Text;
                gv_dto.ngaysinh = DateTime.Parse(dtpNgaySinh.Value.ToString());
                if (rdoNam.Checked)
                {
                    gv_dto.gioitinh = "Nam";
                }
                else
                {
                    gv_dto.gioitinh = "Nữ";
                }
                gv_dto.diachi = txtDiaChi.Text;
                gv_dto.sodienthoai = txtSDT.Text;
                gv_dto.cccd = txtCCCD.Text;
                gv_dto.email = txtEmail.Text;
                gv_dto.ngayvaotruong = DateTime.Parse(dtpNgayVT.Value.ToString());
                gv_dto.ngayvaodang = DateTime.Parse(dtpNgayVD.Value.ToString());
                gv_dto.donvicongtac = txtDonVi.Text;
                gv_dto.dantoc = txtDanToc.Text;
                gv_dto.tongiao = txtTonGiao.Text;
                gv_dto.thamnien = int.Parse(txtThamNien.Text);
                gv_dto.masocd = cboMSCD.SelectedValue.ToString();
                gv_dto.bac = int.Parse(cboBac.SelectedValue.ToString());
                gv_dto.macm = int.Parse(cboChuyenMon.SelectedValue.ToString());

                gv_bll.addGV(gv_dto);

                //------- THÊM TÀI KHOẢN
                tk_dto.magv = pMaGV;
                tk_dto.matkhau = "123123";
                tk_dto.maqtc = 2;

                tk_bll.addTK(tk_dto);

                //------- THÊM CHI TIẾT CHỨC VỤ
                ctcv_dto.magv = pMaGV;
                ctcv_dto.macv = 4;

                ctcv_bll.addCTCV(ctcv_dto);

                MessageBox.Show("GIÁO VIÊN " + gv_dto.hoten.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void loadDataBacLuong()
        {
            string pMaCD = cboMSCD.SelectedValue.ToString();
            cboBac.DataSource = bl_bll.getDataBacLuongTheoMaCD(pMaCD);
            cboBac.DisplayMember = "BAC";
            cboBac.ValueMember = "BAC";
        }

        private void loadDataChucDanh()
        {
            cboMSCD.DataSource = cd_bll.getDataChucDanh();
            cboMSCD.DisplayMember = "MASOCD";
            cboMSCD.ValueMember = "MASOCD";
        }

        private void loadDataChuyenMon()
        {
            cboChuyenMon.DataSource = cm_bll.getDataChuyenMon();
            cboChuyenMon.DisplayMember = "TENCM";
            cboChuyenMon.ValueMember = "MACM";
        }

        private void loadDataTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang dạy");
            cboTrangThai.Items.Add("Nghỉ dạy");

            cboTrangThai.SelectedIndex = 0;
        }

        private string createCode()
        {
            Random random = new Random();
            string pMaGV;

            while (true)
            {
                int randomNumber = random.Next(100000, 1000000);
                pMaGV = "2001" + randomNumber.ToString("D6");

                if (!gv_bll.checkPK(pMaGV))
                {
                    return pMaGV;
                }
            }
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbFrmName_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboChuyenMon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboBac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMSCD_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click_1(object sender, EventArgs e)
        {

        }

        private void rdoNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayVD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayVT_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel10_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel9_Click(object sender, EventArgs e)
        {

        }

        private void txtThamNien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDanToc_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel17_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel19_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel15_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel13_Click(object sender, EventArgs e)
        {

        }

        private void txtTonGiao_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel18_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel16_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel14_Click(object sender, EventArgs e)
        {

        }

        private void txtDonVi_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel12_Click(object sender, EventArgs e)
        {

        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel8_Click(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel6_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel7_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void bigLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
