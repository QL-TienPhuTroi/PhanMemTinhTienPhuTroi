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
    public partial class frmSalaryGrade : Form
    {
        BacLuongBLL bl_bll = new BacLuongBLL();

        public frmSalaryGrade()
        {
            InitializeComponent();
            this.Load += FrmSalaryGrade_Load;
        }

        private void FrmSalaryGrade_Load(object sender, EventArgs e)
        {
            loadDataSalaryGrade();
        }

        private void loadDataSalaryGrade()
        {
            dgvSalaryGrade.DataSource = bl_bll.getDataBacLuong();

            dgvSalaryGrade.Columns[0].HeaderText = "Mã số chức danh";
            dgvSalaryGrade.Columns[1].HeaderText = "Bậc";
            dgvSalaryGrade.Columns[2].HeaderText = "Hệ số lương";
        }
    }
}
