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
        frmAddPosition fAdd;
        frmEditPosition fEdit;
        int pCode;
        public frmPosition()
        {
            InitializeComponent();
            this.Load += FrmPosition_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnRemove.Click += BtnRemove_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged; 
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvPosition.DataSource = cv_bll.findDataChucVuLoc(txtSearch.Text);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int pMaCV = int.Parse(dgvPosition.CurrentRow.Cells[0].Value.ToString());
            string pTenCV = dgvPosition.CurrentRow.Cells[1].Value.ToString();

            if (cv_bll.removeCV(pMaCV))
            {
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG CHỨC VỤ " + pTenCV.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataPosition();
            }
            else
            {
                MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pCode = int.Parse(dgvPosition.CurrentRow.Cells[0].Value.ToString());
            fEdit = new frmEditPosition(pCode);
            fEdit.ShowDialog();
            loadDataPosition();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAdd = new frmAddPosition();
            fAdd.ShowDialog();
            loadDataPosition();
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
