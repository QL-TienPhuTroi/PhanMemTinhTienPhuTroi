using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_TinhTienPhuTroi
{
    public partial class DangNhap : Form
    {
        string tenTK = "admin";
        string matKhau = "123";
        public DangNhap()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraDangNhap(tb_TaiKhoan.Text, tb_MatKhau.Text) == true)
            {
                tb_TaiKhoan.Focus();
                MessageBox.Show("Đăng Nhập thành công", "Đăng Nhập Thành Công");
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không chính xác", "Lỗi");
                tb_TaiKhoan.Focus();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
        bool KiemTraDangNhap(string tenTK, string matKhau)
        {
            if (tenTK == this.tenTK && matKhau == this.matKhau)
            {
                return true;
            }
            return false;
        }
    }
}
