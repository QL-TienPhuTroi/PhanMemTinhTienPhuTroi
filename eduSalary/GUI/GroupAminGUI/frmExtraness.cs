using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GroupAminGUI
{
    public partial class frmExtraness : Form
    {
        PhuTroiBLL pt_bll = new PhuTroiBLL();
        string pNamHoc;

        public frmExtraness(string _namhoc)
        {
            InitializeComponent();
            pNamHoc = _namhoc;
            this.Load += FrmExtraness_Load;
            cboYear.SelectedIndexChanged += CboYear_SelectedIndexChanged;
            btnClearText.Click += BtnClearText_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void FrmExtraness_Load(object sender, EventArgs e)
        {
            loadYear();
            loadDataExtraness();
        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataExtraness();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvExtraness.DataSource = pt_bll.getDataPhuTroiTheoMaGV(txtSearch.Text, cboYear.SelectedItem.ToString());
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void loadDataExtraness()
        {
            dgvExtraness.DataSource = pt_bll.getDataPhuTroi(cboYear.SelectedItem.ToString());

            dgvExtraness.Columns[0].HeaderText = "MSGV";
            dgvExtraness.Columns[1].HeaderText = "Tổng tiết dạy/năm";
            dgvExtraness.Columns[2].HeaderText = "Tổng tiết đã dạy/năm";
            dgvExtraness.Columns[3].HeaderText = "Tổng tiết quy định/năm";
            dgvExtraness.Columns[4].HeaderText = "Số giờ dạy thêm/năm";
            dgvExtraness.Columns[5].HeaderText = "Lương 1 giờ dạy";
            dgvExtraness.Columns[6].HeaderText = "Tiền phụ trội";
        }

        private void loadYear()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int y1, y2;
            string schoolYear = string.Empty;

            cboYear.Items.Clear();

            for (int i = 2023; i < year + 1; i++)
            {
                schoolYear = i + "-" + (i + 1);
                cboYear.Items.Add(schoolYear);
            }

            cboYear.Text = pNamHoc;
        }
    }
}
