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
    public partial class Home : Form
    {
        bool isThoat = true;
        public Home()
        {
            InitializeComponent();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (isThoat == true){
                Application.Exit();
            }
        }
    }
}
