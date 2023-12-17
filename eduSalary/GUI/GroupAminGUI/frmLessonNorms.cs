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
    public partial class frmLessonNorms : Form
    { 
        DinhMucTietDayBLL dmtd_bll = new DinhMucTietDayBLL();
        frmAddLessonNorms fAdd;
        frmEditLessonNorms fEdit;
        int pCode;
        decimal pSoDMTD;
        public frmLessonNorms()
        {
            InitializeComponent();
            this.Load += FrmLessonNorms_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int pMaCV = int.Parse(dgvLessonNorms.CurrentRow.Cells[0].Value.ToString());
            decimal pSoDMTD = decimal.Parse(dgvLessonNorms.CurrentRow.Cells[1].Value.ToString());

            if (dmtd_bll.removeDMTD(pMaCV, pSoDMTD))
            {
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG ĐỊNH MỨC TIẾT DẠY " + pSoDMTD , "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataLessonNorms();
            }
            else
            {
                MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAdd = new frmAddLessonNorms(pCode);
            fAdd.ShowDialog();
            loadDataLessonNorms();
        }

        //private void BtnEdit_Click(object sender, EventArgs e)
        //{
        //    pCode = int.Parse(dgvLessonNorms.CurrentRow.Cells[0].Value.ToString());
        //    pSoDMTD = decimal.Parse(dgvLessonNorms.CurrentRow.Cells[1].Value.ToString());
        //    fEdit = new frmEditLessonNorms(pCode, pSoDMTD);
        //    fEdit.ShowDialog();
        //    loadDataLessonNorms();
        //}

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvLessonNorms.DataSource = dmtd_bll.findDataDinhMucTietDayLoc(txtSearch.Text);

            //dgvLessonNorms.Columns[0].HeaderText = "Mã chức vụ";
            //dgvLessonNorms.Columns[1].HeaderText = "Số định mức tiết dạy";
        }

        private void FrmLessonNorms_Load(object sender, EventArgs e)
        {
            loadDataLessonNorms();
        }
        private void loadDataLessonNorms()
        {
            dgvLessonNorms.DataSource = dmtd_bll.getDataDinhMucTietDay();

            dgvLessonNorms.Columns[0].HeaderText = "Mã chức vụ";
            dgvLessonNorms.Columns[1].HeaderText = "Số định mức tiết dạy";
        }
    }
}
