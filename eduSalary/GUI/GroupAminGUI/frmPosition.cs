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
using DTO;
using BLL;

namespace GUI.GroupAminGUI
{
    public partial class frmPosition : Form
    {
        ChucVuBLL cv_bll = new ChucVuBLL();

        public frmPosition()
        {
            InitializeComponent();
            this.Load += FrmPosition_Load;
        }

        private void FrmPosition_Load(object sender, EventArgs e)
        {
            loadDataPosition();
        }

        private void loadDataPosition()
        {
            dgvPosition.DataSource = cv_bll.getDataChucVu();

            dgvPosition.Columns[0].HeaderText = "Mã chức vụ";
            dgvPosition.Columns[1].HeaderText = "Tên chức vụ";
        }
    }
}
