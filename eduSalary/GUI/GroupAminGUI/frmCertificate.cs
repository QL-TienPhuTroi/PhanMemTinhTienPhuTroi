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
    public partial class frmCertificate : Form
    {
        BangCapBLL bc_bll = new BangCapBLL();
        frmDetailedProfile fDetailedProfile;
        frmAddCertificate fAddCertificate;
        frmEditCertificate fEditCertificate;
        string pCode;
        public frmCertificate()
        {
            InitializeComponent();
            this.Load += FrmCertificate_Load;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnEdit.Click += BtnEdit_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvCertificates.DataSource = bc_bll.findDataBangCapLoc(txtSearch.Text);

            //dgvCertificates.Columns[0].HeaderText = "Mã bằng cấp";
            //dgvCertificates.Columns[1].HeaderText = "Tên bằng cấp";
            //dgvCertificates.Columns[2].HeaderText = "Nơi đào tạo";
            //dgvCertificates.Columns[3].HeaderText = "CHuyên ngành";
            //dgvCertificates.Columns[1].HeaderText = "Học vị";
            //dgvCertificates.Columns[2].HeaderText = "Xếp loại";
            //dgvCertificates.Columns[3].HeaderText = "ngày cấp";
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            pCode = dgvCertificates.CurrentRow.Cells[0].Value.ToString();
            fEditCertificate = new frmEditCertificate(pCode);
            fEditCertificate.ShowDialog();
            loadDataBangCap();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            string pMaBC = dgvCertificates.CurrentRow.Cells[0].Value.ToString();
            string pTenBC = dgvCertificates.CurrentRow.Cells[1].Value.ToString();
            string pNoiDaoTao = dgvCertificates.CurrentRow.Cells[2].Value.ToString();
            string pChuyenNganh = dgvCertificates.CurrentRow.Cells[3].Value.ToString();
            string pHocVi = dgvCertificates.CurrentRow.Cells[4].Value.ToString();
            string pXepLoai = dgvCertificates.CurrentRow.Cells[5].Value.ToString();
            DateTime pNgayCap = DateTime.Parse(dgvCertificates.CurrentRow.Cells[6].Value.ToString());
            if (bc_bll.removeBC(pMaBC))
            {
                MessageBox.Show("ĐÃ XÓA THÀNH CÔNG BẲNG CẤP " + pTenBC.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataBangCap();
            }
            else
            {
                MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fAddCertificate = new frmAddCertificate();
            fAddCertificate.ShowDialog();
            loadDataBangCap();
        }

        private void FrmCertificate_Load(object sender, EventArgs e)
        {
            loadDataBangCap();
        }
        private void loadDataBangCap()
        {
            dgvCertificates.DataSource = bc_bll.getDataBangCap();

            dgvCertificates.Columns[0].HeaderText = "Mã bằng cấp";
            dgvCertificates.Columns[1].HeaderText = "Tên bằng cấp";
            dgvCertificates.Columns[2].HeaderText = "Nơi đào tạo";
            dgvCertificates.Columns[3].HeaderText = "Chuyên ngành";
            dgvCertificates.Columns[4].HeaderText = "Học vị";
            dgvCertificates.Columns[5].HeaderText = "Xếp loại";
            dgvCertificates.Columns[6].HeaderText = "Ngày cấp";
        }
    }
}
