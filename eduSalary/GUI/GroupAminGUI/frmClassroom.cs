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
        frmDetailedProfile fDetailedProfile;
        frmAddClassroom fAddClassroom;
        frmEditClassroom fEditClassroom;
        string pCode;
        public frmClassroom()
        {
            InitializeComponent();
            this.Load += FrmClassroom_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnRemove.Click += BtnRemove_Click;
            dgvClassroom.DoubleClick += DgvClassroom_DoubleClick;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvClassroom.DataSource = lp_bll.findDataLopHoc(txtSearch.Text);
        }

        private void DgvClassroom_DoubleClick(object sender, EventArgs e)
        {
            pCode = dgvClassroom.CurrentRow.Cells[0].Value.ToString();
            fDetailedProfile = new frmDetailedProfile(pCode);
            fDetailedProfile.ShowDialog();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadDataClassroom();
            txtSearch.ResetText();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            string pMaLP = dgvClassroom.CurrentRow.Cells[0].Value.ToString();
            string pTenLP = dgvClassroom.CurrentRow.Cells[1].Value.ToString();

            if (lp_bll.removeLP(pMaLP))
            {
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG LỚP " + pTenLP.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataClassroom();
            }
            else
            {
                MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pCode = dgvClassroom.CurrentRow.Cells[0].Value.ToString();
            fEditClassroom = new frmEditClassroom(pCode);
            fEditClassroom.ShowDialog();
            loadDataClassroom();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddClassroom = new frmAddClassroom();
            fAddClassroom.ShowDialog();
            loadDataClassroom();
        }

        private void FrmClassroom_Load(object sender, EventArgs e)
        {
            loadDataClassroom();
        }

        private void loadDataClassroom()
        {
            dgvClassroom.DataSource = lp_bll.getDataLopHoc();


            dgvClassroom.Columns[0].HeaderText = "Mã lớp";
            dgvClassroom.Columns[1].HeaderText = "Tên Lớp";
            dgvClassroom.Columns[2].HeaderText = "Sĩ số";
            dgvClassroom.Columns[3].HeaderText = "Khiếm khuyết";
            dgvClassroom.Columns[4].HeaderText = "Mã khối";
        }
    }
}
