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
        frmEditSalaryGrade fEdit;
        string pCode;
        int pBac;
        public frmSalaryGrade()
        {
            InitializeComponent();
            this.Load += FrmSalaryGrade_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnEdit.Click += BtnEdit_Click;

        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pCode = dgvSalaryGrade.CurrentRow.Cells[0].Value.ToString();
            pBac = int.Parse(dgvSalaryGrade.CurrentRow.Cells[1].Value.ToString());
            fEdit = new frmEditSalaryGrade(pCode, pBac);
            fEdit.ShowDialog();
            loadDataSalaryGrade();
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSalaryGrade.DataSource = bl_bll.findDataBangCapLoc(txtSearch.Text);
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
            dgvSalaryGrade.Columns[3].HeaderText = "Mức lương cơ sở";
        }
    }
}
