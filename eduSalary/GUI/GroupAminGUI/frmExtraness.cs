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

        public frmExtraness()
        {
            InitializeComponent();
            this.Load += FrmExtraness_Load;
            btnClearText.Click += BtnClearText_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void FrmExtraness_Load(object sender, EventArgs e)
        {
            loadDataExtraness();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void loadDataExtraness()
        {
            dgvExtraness.DataSource = pt_bll.getDataPhuTroi();

            dgvExtraness.Columns[0].HeaderText = "MSGV";
            dgvExtraness.Columns[1].HeaderText = "Tổng tiết dạy/năm";
            dgvExtraness.Columns[2].HeaderText = "Số giờ dạy thêm/năm";
            dgvExtraness.Columns[3].HeaderText = "Lương 1 giờ dạy";
            dgvExtraness.Columns[4].HeaderText = "Tiền phụ trội";
        }
    }
}
