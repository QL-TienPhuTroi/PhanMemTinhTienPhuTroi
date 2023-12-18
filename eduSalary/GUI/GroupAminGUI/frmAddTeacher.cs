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
using System.Text.RegularExpressions;

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
            dtpNgaySinh.ValueChanged += DtpNgaySinh_ValueChanged;
            dtpThamNien.ValueChanged += DtpThamNien_ValueChanged;
            dtpNgayVT.ValueChanged += DtpNgayVT_ValueChanged;
            dtpNgayVD.ValueChanged += DtpNgayVD_ValueChanged;

            txtSDT.KeyPress += TxtSDT_KeyPress;
            txtSDT.Validating += TxtSDT_Validating;

            txtCCCD.KeyPress += TxtCCCD_KeyPress;
            txtCCCD.Validating += TxtCCCD_Validating;

            txtEmail.KeyPress += TxtEmail_KeyPress;
            txtEmail.Validating += TxtEmail_Validating;
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!IsEmailValid(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Thông báo");
                txtEmail.Focus();
                e.Cancel = true;
            }
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TxtCCCD_Validating(object sender, CancelEventArgs e)
        {
            if (txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("Số điện thoại phải có 12 chữ số.", "PHẦN MỀM TÍNH PHỤ TRỘI");
                txtCCCD.Focus();
            }
        }

        private void TxtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TxtSDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số.", "PHẦN MỀM TÍNH PHỤ TRỘI");
                txtSDT.Focus();
            }
        }

        private void TxtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void DtpNgayVD_ValueChanged(object sender, EventArgs e)
        {
            DateTime maxDate = DateTime.Now;

            if (dtpNgayVD.Value > maxDate)
            {
                MessageBox.Show("THỜI GIAN KHÔNG HỢP LỆ! ", "PHẦN MỀM TÍNH PHỤ TRỘI");
                dtpNgayVD.Value = maxDate;
            }
        }

        private void DtpNgayVT_ValueChanged(object sender, EventArgs e)
        {
            DateTime maxDate = DateTime.Now;

            if (dtpNgayVT.Value > maxDate)
            {
                MessageBox.Show("THỜI GIAN KHÔNG HỢP LỆ! ", "PHẦN MỀM TÍNH PHỤ TRỘI");
                dtpNgayVT.Value = maxDate;
            }
        }

        private void DtpThamNien_ValueChanged(object sender, EventArgs e)
        {
            DateTime maxDate = DateTime.Now;
            DateTime minDate = dtpNgaySinh.Value.AddYears(21);

            if (dtpThamNien.Value > maxDate && dtpThamNien.Value < minDate)
            {
                MessageBox.Show("THỜI GIAN KHÔNG HỢP LỆ! ", "PHẦN MỀM TÍNH PHỤ TRỘI");
                dtpThamNien.Value = maxDate;
            }
        }

        private void DtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            DateTime maxDate = DateTime.Now.AddYears(-21);

            if (dtpNgaySinh.Value > maxDate)
            {
                MessageBox.Show("CHƯA ĐỦ TUỔI ĐỂ LÀM VIỆC! ", "PHẦN MỀM TÍNH PHỤ TRỘI");
                dtpNgaySinh.Value = maxDate;
            }
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

            DateTime maxDate = DateTime.Now.AddYears(-21);
            dtpNgaySinh.Value = maxDate;
            dtpThamNien.Value = DateTime.Now;
            dtpNgayVT.Value = DateTime.Now;
            dtpNgayVD.Value = DateTime.Now;
            rdoNam.Checked = true;
            cboMSCD.SelectedIndex = cboMSCD.Items.Count - 1;
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
                gv_dto.donvicongtac = "Trường THPT Bình Sơn";
                gv_dto.dantoc = txtDanToc.Text;
                gv_dto.tongiao = txtTonGiao.Text;
                gv_dto.thamnien = DateTime.Now.Year - dtpThamNien.Value.Year;
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

        private bool IsEmailValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }


    }
}
