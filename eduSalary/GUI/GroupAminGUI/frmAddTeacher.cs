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
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            string pMaGV = createCode();

            try
            {
                gv_dto.magv = pMaGV;
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
                MessageBox.Show("GIÁO VIÊN " + gv_dto.hoten + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
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
    }
}
