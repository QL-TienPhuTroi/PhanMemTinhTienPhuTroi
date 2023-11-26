using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.GroupAminGUI
{
    public partial class frmClassroom : Form
    {
        LopHocBLL lp_bll = new LopHocBLL();

        public frmClassroom()
        {
            InitializeComponent();
            this.Load += FrmClassroom_Load;
        }

        private void FrmClassroom_Load(object sender, EventArgs e)
        {
            loadDataClassroom();
        }

        private void loadDataClassroom()
        {
            dgvClassroom.DataSource = lp_bll.getDataLopHoc();

            dgvClassroom.Columns[0].HeaderText = "Mã lớp";
            dgvClassroom.Columns[1].HeaderText = "Tên lớp";
            dgvClassroom.Columns[2].HeaderText = "Sĩ số";
            dgvClassroom.Columns[3].HeaderText = "Khiếm khuyết";
        }
    }
}
