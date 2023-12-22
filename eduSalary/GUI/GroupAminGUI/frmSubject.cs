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
    public partial class frmSubject : Form
    {
        MonHocBLL mh_bll = new MonHocBLL();
        frmDetailedProfile fDetailedProfile;
        frmAddSubject fAdd;
        frmEditSubject fEdit;
        int pCode;
        public frmSubject()
        {
            InitializeComponent();
            btnEdit.Click += BtnEdit_Click;
            this.Load += FrmSubject_Load; ;
            dgvSubjects.DoubleClick += DgvSubjects_DoubleClick; ;
            btnAdd.Click += BtnAdd_Click; ;
            btnRemove.Click += BtnRemove_Click; ;
            btnEdit.Click += BtnEdit_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged; ;
        }

        private void FrmSubject_Load(object sender, EventArgs e)
        {
            loadDataSubject();
        }

        private void DgvSubjects_DoubleClick(object sender, EventArgs e)
        {
            pCode = int.Parse(dgvSubjects.CurrentRow.Cells[0].Value.ToString());
            fDetailedProfile = new frmDetailedProfile(pCode.ToString());
            fDetailedProfile.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAdd = new frmAddSubject();
            fAdd.ShowDialog();
            loadDataSubject();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            string pMaMH = dgvSubjects.CurrentRow.Cells[0].Value.ToString();
            string pTenGV = dgvSubjects.CurrentRow.Cells[1].Value.ToString();

            if (mh_bll.removeMH(int.Parse(pMaMH)))
            {
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG MÔN HỌC " + pTenGV.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataSubject();
            }
            else
            {
                MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadDataSubject();
            txtSearch.ResetText();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSubjects.DataSource = mh_bll.findDataMonHoc(txtSearch.Text);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pCode = int.Parse(dgvSubjects.CurrentRow.Cells[0].Value.ToString());
            fEdit = new frmEditSubject(pCode);
            fEdit.ShowDialog();
            loadDataSubject();
        }
        private void loadDataSubject()
        {
            dgvSubjects.DataSource = mh_bll.getDataMonHoc();

            dgvSubjects.Columns[0].HeaderText = "Mã môn học";
            dgvSubjects.Columns[1].HeaderText = "Tên môn học";
            dgvSubjects.Columns[2].HeaderText = "Số tiết tối đa";
            dgvSubjects.Columns[3].HeaderText = "Mã chuyên môn";
            dgvSubjects.Columns[4].HeaderText = "Mã khối";
        }
    }
}
