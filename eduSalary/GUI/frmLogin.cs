using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        GiaoVienBLL gv_bll = new GiaoVienBLL();

        public frmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
            txtCode.KeyDown += TxtCode_KeyDown;
            txtPS.KeyDown += TxtPS_KeyDown;
            btnHidePS.Click += BtnHidePS_Click;
            btnLogin.Click += BtnLogin_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtPS.UseSystemPasswordChar = true;
            txtCode.Text = Properties.Settings.Default.code;
            txtPS.Text = Properties.Settings.Default.password;
            chkRememberPS.Checked = Properties.Settings.Default.isRemember;
        }

        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void TxtPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnHidePS_Click(object sender, EventArgs e)
        {
            if (btnHidePS.Tag.ToString() == "hidePS")
            {
                txtPS.UseSystemPasswordChar = false;
                btnHidePS.Tag = "showPS";
                Image showPass = Properties.Resources.view;
                btnHidePS.Image = showPass;
                return;
            }
            else
            {
                txtPS.UseSystemPasswordChar = true;
                btnHidePS.Tag = "hidePS";
                Image hidePass = Properties.Resources.hide;
                btnHidePS.Image = hidePass;
                return;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string pCode = txtCode.Text.Trim();
            string pPassword = txtPS.Text.Trim();
            
            if(pCode == string.Empty && pPassword == string.Empty)
            {
                lbCode.ResetText();
                lbPS.ResetText();
                lbCode.Text = "Bạn đã quên điền mã giáo viên rồi!";
                lbPS.Text = "Bạn đã quên điền mật khẩu rồi!";
                txtCode.Focus();
                return;
            }
            else if (pCode == string.Empty)
            {
                lbCode.ResetText();
                lbPS.ResetText();
                lbCode.Text = "Bạn đã quên điền mã giáo viên rồi!";
                txtCode.Focus();
                return;
            }
            else if (pPassword == string.Empty)
            {
                lbCode.ResetText();
                lbPS.ResetText();
                lbPS.Text = "Bạn đã quên điền mật khẩu rồi!";
                txtPS.Focus();
                return;
            }
            else
            {
                if(gv_bll.isSuccessLogin(pCode, pPassword))
                {
                    rememberPS(pCode, pPassword);
                    frmLoading fLoading = new frmLoading(pCode, pPassword);
                    fLoading.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("VUI LÒNG KIỂM TRA LẠI THÔNG TIN ĐĂNG NHẬP?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("BẠN CÓ CHẮC MUỐN THOÁT?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void rememberPS(string pCode, string pPassword)
        {
            if (chkRememberPS.Checked)
            {
                Properties.Settings.Default.code = pCode;
                Properties.Settings.Default.password = pPassword;
                Properties.Settings.Default.isRemember = true;

                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.code = pCode;
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.isRemember = false;

                Properties.Settings.Default.Save();
            }
        }

    }
}
