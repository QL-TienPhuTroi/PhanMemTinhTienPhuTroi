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
    public partial class frmTeacher : Form
    {
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        frmDetailedProfile fDetailedProfile;
        frmAddTeacher fAdd;
        frmEditTeacher fEdit;

        string pCode;

        public frmTeacher()
        {
            InitializeComponent();
            this.Load += FrmTeacher_Load;
            dgvTeacher.DoubleClick += DgvTeacher_DoubleClick;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnEdit.Click += BtnEdit_Click;
            btnLoad.Click += BtnLoad_Click;
            btnClearText.Click += BtnClearText_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvTeacher.DataSource = gv_bll.findDataGiaoVienLoc(txtSearch.Text);

            dgvTeacher.Columns[0].HeaderText = "MSGV";
            dgvTeacher.Columns[1].HeaderText = "Họ tên";
            dgvTeacher.Columns[2].HeaderText = "Ngày sinh";
            dgvTeacher.Columns[3].HeaderText = "Giới tính";
        }

        private void BtnClearText_Click(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pCode = dgvTeacher.CurrentRow.Cells[0].Value.ToString();
            fEdit = new frmEditTeacher(pCode);
            fEdit.ShowDialog();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            string pMaGV = dgvTeacher.CurrentRow.Cells[0].Value.ToString();
            string pTenGV = dgvTeacher.CurrentRow.Cells[1].Value.ToString();

            if (gv_bll.removeGV(pMaGV))
            {
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG GIÁO VIÊN " + pTenGV, "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataTeacher();
            }
            else
            {
                MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAdd = new frmAddTeacher();
            fAdd.ShowDialog();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadDataTeacher();
            txtSearch.ResetText();
        }

        private void DgvTeacher_DoubleClick(object sender, EventArgs e)
        {
            pCode = dgvTeacher.CurrentRow.Cells[0].Value.ToString();
            fDetailedProfile = new frmDetailedProfile(pCode);
            fDetailedProfile.ShowDialog();
        }

        private void FrmTeacher_Load(object sender, EventArgs e)
        {
            loadDataTeacher();
        }

        private void loadDataTeacher()
        {
            dgvTeacher.DataSource = gv_bll.getDataGiaoVienLoc();

            dgvTeacher.Columns[0].HeaderText = "MSGV";
            dgvTeacher.Columns[1].HeaderText = "Họ tên";
            dgvTeacher.Columns[2].HeaderText = "Ngày sinh";
            dgvTeacher.Columns[3].HeaderText = "Giới tính";
        }
    }
}
