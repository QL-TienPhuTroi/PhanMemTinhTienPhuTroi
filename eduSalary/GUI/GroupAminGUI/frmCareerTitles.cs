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

namespace GUI.GroupAminGUI
{
    public partial class frmCareerTitles : Form
    {
        ChucDanhBLL cd_bll = new ChucDanhBLL();

        public frmCareerTitles()
        {
            InitializeComponent();
            this.Load += FrmCareerTitles_Load;
        }

        private void FrmCareerTitles_Load(object sender, EventArgs e)
        {
            loadDataCareerTitles();
        }

        private void loadDataCareerTitles()
        {
            dgvCareerTitles.DataSource = cd_bll.getDataChucDanh();

            dgvCareerTitles.Columns[0].HeaderText = "Mã số chức danh";
            dgvCareerTitles.Columns[1].HeaderText = "Hạng chức danh";
        }
    }
}
